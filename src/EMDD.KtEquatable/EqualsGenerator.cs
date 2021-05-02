using EMDD.KtEquatable.Core;
using EMDD.KtSourceGen.KtEquatable.Syntax;
using EMDD.KtSourceGen.KtEquatable.Syntax.Property;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using static EMDD.KtEquatable.Core.CoreHelpers;
using static EMDD.KtSourceGen.KtEquatable.Syntax.SyntaxGenerators;
namespace EMDD.KtSourceGen.KtEquatable
{
    [Generator]
    internal class EqualsGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            //#if DEBUG
            //            Debugger.Launch();
            //#endif
            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxReceiver is not SyntaxReceiver s) return;
            var symbolCollection = TypeSymbolCollection.Create(context);
            foreach (var node in s.CandidateSyntaxes)
            {
                var symbol = context.GetSymbol(node);
                if (!symbol.HasAttribute(symbolCollection.Equatable)) continue;
                var typeName = symbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat);
                var iequatableImp = context.GetIEquatableSymbol(symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat));
                if (symbol.ImplementsEquatable()) continue;
                var baseType = symbol.BaseType;
                var baseTypeName = baseType?.ToFullyQualifiedFormat();
                var iequatableImpOnBase = context.GetIEquatableSymbol(baseTypeName);
                var baseImplementsIEqu = baseType.ImplementsEquatable() || baseType.HasAttribute(symbolCollection.Equatable);
                TypeSyntaxWithProps type = node switch
                {
                    RecordDeclarationSyntax _ => new RecordSyntax { Name = typeName, BaseImplementsEquatable = baseImplementsIEqu, BaseName = baseTypeName, IsSealed = symbol.IsSealed, TypeDec = "record" },
                    ClassDeclarationSyntax _ => new ClassSyntax { BaseName = baseTypeName, Name = typeName, BaseImplementsEquatable = baseImplementsIEqu },
                    _ => throw new Exception("Type does not exist, Struct Type soon to be included, or a PR would be nice too.")
                };
                var isRecord = node is RecordDeclarationSyntax;
                var props = symbol.GetProperties();
                if (type.IsDerived && !type.BaseImplementsEquatable)
                {
                    props = baseType.GetProperties().Concat(props);
                }
                foreach (var property in props)
                {
                    var p = symbolCollection.ToPropertyEquality(property, isRecord);
                    if (p is PropertyDefaultEquality d)
                    {
                        type.PropertiesSytax.Add(d);
                    }
                }
                var parentString = type.AssignAndGetParent(symbol).BuildString();
                var usingStatements = BuildUsingStatements(type.PropertiesSytax.Any(p => p is PropertyHasCustomComparer));
                var finalstring = usingStatements + "\n" + parentString;
                context.AddSource($"{symbol!.ToDisplayString().ReplaceEscapeChars()}.{SourceGenName}.g.cs"!, SourceText.From(finalstring, Encoding.UTF8));
            }
        }

        private static string BuildUsingStatements(bool usedCustomComparer)
        {
            var sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.Append("using System.CodeDom.Compiler;");
            if (usedCustomComparer)
            {
                sb.Append("\n").Append("using ").Append(NameSpace).Append(".Core.EqualityComparers;");
            }
            return sb.ToString();
        }

        private class SyntaxReceiver : ISyntaxReceiver
        {
            private readonly List<SyntaxNode> _candidateSyntaxes = new();

            public IReadOnlyList<SyntaxNode> CandidateSyntaxes => _candidateSyntaxes;

            public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
            {
                if (syntaxNode is not ClassDeclarationSyntax and not RecordDeclarationSyntax) return;
                _candidateSyntaxes.Add(syntaxNode);
            }
        }
    }
}
