using EMDD.KtEquatable.Core.Attributes;
using EMDD.KtEquatable.Core.EqualityComparers;
using EMDD.KtEquatable.Syntax;
using EMDD.KtEquatable.Syntax.Property;
using EMDD.KtEquatable.Syntax.Property.Base;
using EMDD.KtEquatable.Syntax.Property.HasCustomComparer;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Text;

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using static EMDD.KtEquatable.Core.CoreHelpers;
using static EMDD.KtEquatable.Core.DiagnosticData;

namespace EMDD.KtEquatable.Core
{
    internal sealed class AttributeTypeSymbols
    {
        public AttributeTypeSymbols(GeneratorExecutionContext context)
        {
            EnumerableEquality = context.Compilation.GetTypeByMetadataName(typeof(EnumerableEqualityAttribute).FullName)!;
            IgnoreEquality = context.Compilation.GetTypeByMetadataName(typeof(IgnoreEqualityAttribute).FullName)!;
            ReferenceEquality = context.Compilation.GetTypeByMetadataName(typeof(ReferenceEqualityAttribute).FullName)!;
            FloatingPointEquality = context.Compilation.GetTypeByMetadataName(typeof(FloatingPointEqualityAttribute).FullName)!;
        }

        public INamedTypeSymbol EnumerableEquality { get; set; }
        public INamedTypeSymbol IgnoreEquality { get; set; }
        public INamedTypeSymbol ReferenceEquality { get; set; }
        public INamedTypeSymbol FloatingPointEquality { get; set; }
    }

    public sealed class GeneratorWriter
    {
        public INamedTypeSymbol Equatable { get; }
        public List<(string className, SourceText st)> SourceTexts { get; } = new List<(string className, SourceText st)>();
        public List<Diagnostic> Diagnostics { get; } = new List<Diagnostic>();

        internal AttributeTypeSymbols Atts { get; }
        private readonly AnalyzerConfigOptionsProvider _config;

        public static GeneratorWriter Create(GeneratorExecutionContext context) => new(context);

        private GeneratorWriter(GeneratorExecutionContext context)
        {
            Equatable = context.Compilation.GetTypeByMetadataName(typeof(EquatableAttribute).FullName)!;
            Atts = new AttributeTypeSymbols(context);
            _config = context.AnalyzerConfigOptions;
        }

        public void AddRecordSourceText(RecordDeclarationSyntax node, ITypeSymbol symbol)
        {
            var bc = new BaseType(symbol.BaseType, Equatable);
            AddToSourceText<RecordSyntax>(symbol, bc, node, SyntaxGenerators.IsEqualityContract);
        }

        public void AddClassSourceText(ClassDeclarationSyntax node, ITypeSymbol symbol)
        {
            if (symbol.ImplementsIEquatable())
            {
                Diagnostics.Add(DiagnosticData.Create(RedundantIEquatable, symbol, node));
                return;
            }
            if (symbol.IsStatic)
            {
                Diagnostics.Add(DiagnosticData.Create(StaticClass, symbol, node));
                return;
            }
            var bc = new BaseType(symbol.BaseType, Equatable);
            if (!bc.IsBaseObject && !bc.MarkedAsEquatable && !bc.MarkedWithIEquatable)
            {
                Diagnostics.Add(DiagnosticData.Create(BaseNonIEquatable, symbol, node));
                return;
            }
            AddToSourceText<ClassSyntax>(symbol, bc, node, _ => false);
        }

        private void AddToSourceText<T>(ITypeSymbol symbol, BaseType bc, TypeDeclarationSyntax node, Func<IPropertySymbol, bool> ignoreProp) where T : EquatableTypeSyntax, new()
        {
            T syntax = new();
            syntax.Name = symbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat);
            syntax.BaseType = bc;
            syntax.IsAbstract = symbol.IsAbstract;
            syntax.IsSealed = symbol.IsSealed;
            foreach (var (prop, equalityString, diag) in symbol.GetProperties().Select(ToPropertyData))
            {
                if (diag is not null)
                {
                    Diagnostics.Add(DiagnosticData.Create(diag, prop, node));
                }
                if (ignoreProp(prop)) continue;
                if (equalityString is not null and PropertyDefaultEquality d)
                {
                    syntax.PropertiesSytax.Add(d);
                }
            }
            var indent = node.SyntaxTree.GetIndention(_config);
            var stringwritter = new StringWriter();
            var indented = new IndentedTextWriter(stringwritter, indent);
            indented.WriteLine("using System;");
            indented.WriteLine("using System.Collections.Generic;");
            indented.WriteLine("using System.CodeDom.Compiler;");
            indented.WriteLine("using EMDD.KtEquatable.Core.EqualityComparers;");
            if (syntax.PropertiesSytax.Any(p => p is PropertyHasCustomComparer))
            {
                indented.WriteLine($"using {NameSpace}.Core.EqualityComparers;");
            }
            if (syntax.PropertiesSytax.Any(p => p is DoubleEnumerableEquality || p is PropertyFloatingPointEquality))
            {
                indented.WriteLine($"using {NameSpace}.Core;");
            }
            syntax.AssignAndGetParent(symbol).BuildString(indented);
            SourceTexts.Add((symbol!.ToDisplayString(), SourceText.From(stringwritter.ToString(), Encoding.UTF8)));
        }

        private (IPropertySymbol prop, PropertyEqualityBase propBase, TypeInfo<IPropertySymbol> diag) ToPropertyData(IPropertySymbol property)
        {
            var propType = property.Type;
            var propertyName = property.ToFullyQualifiedFormat();
            var typeName = propType.ToNullableFullyQualifiedFormat();
            var defaultComp = new PropertyDefaultEquality() { Name = propertyName, Type = typeName };
            var atts = property.GetAttributes();
            if (property.IsWriteOnly)
            {
                return (property, new PropertyIgnoreEquality(), atts.Length > 0 ? CantIncludeIndexer : null);
            }
            if (property.IsIndexer)
            {
                return (property, new PropertyIgnoreEquality(), atts.Length > 0 ? PropertyIsWriteOnly : null);
            }
            if (property.HasAttribute(Atts.IgnoreEquality))
            {
                return (property, new PropertyIgnoreEquality(), atts.Length > 1 ? OtherAttributesIgnored : null);
            }
            if (property.HasAttribute(Atts.EnumerableEquality))
            {
                if (propType.TryGetIDictionaryInterface(out var _, out var args))
                {
                    var at = property.GetAttribute(Atts.EnumerableEquality);
                    if (at?.ConstructorArguments[0].IsNull == false)
                    {
                        switch ((EnumerableOrderType)(at.ConstructorArguments[0].Value))
                        {
                            case EnumerableOrderType.Ordered:
                                return (property, defaultComp, DictionaryCantBeOrderedType);
                            case EnumerableOrderType.Set:
                                return (property, defaultComp, DictionaryCantBeSetType);
                            default:
                                var valType = args[1];
                                var valTypeName = valType.ToNullableFullyQualifiedFormat();                             var keyType = args[0];
                                var keyTypeName = keyType.ToNullableFullyQualifiedFormat();
                                var (diag, str) = IndividualAtt(property, valType);
                                return (property, new PropertyWithComparerEquality
                                {
                                    NewOfComparer = $"new DictionaryEqualityComparer<{typeName}, {keyTypeName}, {valTypeName}>({str})",
                                    Name = propertyName
                                }, diag);
                        }
                    }
                }
                else if (propType.TryGetIEnumerableInterface(out var _, out var args2))
                {
                    var valType = args2[0];
                    var valTypeName = valType.ToNullableFullyQualifiedFormat();
                    var (diag, str) = IndividualAtt(property, valType);
                    var at = property.GetAttribute(Atts.EnumerableEquality);
                    if (at?.ConstructorArguments[0].IsNull == false)
                    {
                        var orderType = (EnumerableOrderType)at.ConstructorArguments[0].Value;
                        return (property, new PropertyWithComparerEquality
                        {
                            NewOfComparer = orderType switch
                            {
                                EnumerableOrderType.Ordered =>
                                $"new OrderedEqualityComparer<{typeName}, {valTypeName}>({str})",
                                EnumerableOrderType.Set =>
                                $"new SetEqualityComparer<{typeName}, {valTypeName}>({str})",
                                _ =>
                                $"new UnorderedEqualityComparer<{typeName}, {valTypeName}>({str})"
                            },
                            Name = propertyName
                        }, diag);
                    }
                }
                else
                {
                    return (property, defaultComp, WrongTypeApplication);
                }
            }
            else
            {
                var (diag, str) = IndividualAtt(property, propType);
                return (property, new PropertyWithComparerEquality { Name = propertyName, NewOfComparer = str }, diag);
            }
            return (property, defaultComp, null);
        }

        private (TypeInfo<IPropertySymbol> diag, string comparerNewer) IndividualAtt(IPropertySymbol property, ITypeSymbol propType)
        {
            var typeName = propType.ToNullableFullyQualifiedFormat();
            if (property.HasAttribute(Atts.ReferenceEquality))
            {
                var match = propType.TypeKind == TypeKind.Class && !propType.IsValueType;
                if (!match)
                {
                    return (ReferenceEqualityMustBeClass, $"EqualityComparer<{typeName}>.Default");
                }
                return (null, $"ReferenceEqualityComparer<{typeName}>.Default");
            }
            else if (property.HasAttribute(Atts.FloatingPointEquality))
            {
                if (!propType.IsDouble() && !propType.IsSingle())
                {
                    return (WrongTypeApplication, $"EqualityComparer<{typeName}>.Default");
                }
                var at = property.GetAttribute(Atts.FloatingPointEquality);
                if (at?.ConstructorArguments[0].IsNull == false && at.ConstructorArguments[0].Value is int precision)
                {
                    if (precision < 0)
                    {
                        return (FloatingPointPrecisionLessZero, $"EqualityComparer<{typeName}>.Default");
                    }
                    else
                    {
                        return (null, $"new FloatingPointEqualityComparer({precision})");
                    }
                }
                return (FloatingPointPrecisionIsMissing, $"EqualityComparer<{typeName}>.Default");
            }
            else
            {
                return (null, $"EqualityComparer<{typeName}>.Default");
            }
        }
    }
}
