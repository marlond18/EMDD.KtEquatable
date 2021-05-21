
using EMDD.KtEquatable.Core.EqualityComparers;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace EMDD.KtEquatable.Syntax
{
    public static class SyntaxGenerators
    {
        public static bool IsEqualityContract(this IPropertySymbol symbol) =>
            symbol.ToNullableFullyQualifiedFormat() == "EqualityContract";

        public static string GetIndention(this SyntaxTree tree, AnalyzerConfigOptionsProvider optionsProvider)
        {
            var options = optionsProvider.GetOptions(tree);
            if (options.TryGetValue("indent_style", out var indentStyle))
            {
                if (string.Equals(indentStyle, "tab", StringComparison.OrdinalIgnoreCase)) return "\t";
                if (string.Equals(indentStyle, "space", StringComparison.OrdinalIgnoreCase))
                {
                    var size = options.TryGetValue("indent_size", out var indentSize) ?
                    (uint.TryParse(indentSize, out var indentSizeValue) ? indentSizeValue : 3u) :
                    3u;
                    return new string(' ', (int)size);
                }
            }
            return "\t";
        }

#nullable enable
        public static bool GetAttributeParamVal<T>(this INamedTypeSymbol baseSymbol, INamedTypeSymbol attrSymbol, string propName, out T? value)
        {
            value = default;
            if (baseSymbol.HasAttribute(attrSymbol) && baseSymbol.GetAttribute(attrSymbol).GetParamVal(propName, out T? value2))
            {
                value = value2;
                return true;
            }
            return false;
        }
        public static bool GetParamVal<T>(this AttributeData? at, string propName, out T? value)
        {
            value = default;
            if (at is not null)
            {
                var parameterSymbol = at.AttributeConstructor?.Parameters.FirstOrDefault(cp => cp.Name == propName);
                if (parameterSymbol is null) return false;
                var parameterIdx = (at.AttributeConstructor?.Parameters.IndexOf(parameterSymbol)) ?? -1;
                if (parameterIdx < 0) return false;
                TypedConstant paramStr = at.ConstructorArguments[parameterIdx];
                if (!paramStr.IsNull && paramStr.Value is T val)
                {
                    value = val;
                    return true;
                }
            }
            return false;
        }
#nullable disable
        public static INamedTypeSymbol GetSymbol(this GeneratorExecutionContext context, string fullyQualifiedMetadataName) =>
        context.Compilation.GetTypeByMetadataName(fullyQualifiedMetadataName);

        public static INamedTypeSymbol GetIEquatableSymbol(this GeneratorExecutionContext context, string baseType) =>
            context.Compilation.GetTypeByMetadataName($"System.IEquatable<{baseType}>");

        public static bool ImplementsIEquatable(this ITypeSymbol symbol)
        {
            if (symbol.ToFullyQualifiedFormat() == "object") return false;
            return symbol.Interfaces.Any(i => i.Name.Contains("IEquatable"));
        }

#nullable enable
        public static bool SymbolEquals(this ISymbol? symbol1, ISymbol? symbol2)
        {
            return SymbolEqualityComparer.Default.Equals(symbol1, symbol2);
        }
#nullable restore

        public static bool ImplementsIEnumerableDouble(this ITypeSymbol symbol)
        {
            if (symbol is INamedTypeSymbol named)
            {
                if (named.IsIEnumerableAndDouble()) return true;
                if (named.IsDictionary() && named.TypeArguments[1].IsDouble()) return true;
            }
            return symbol.Interfaces.Length > 0 && symbol.Interfaces.Any(ImplementsIEnumerableDouble);
        }

        private static bool IsIEnumerableAndDouble(this INamedTypeSymbol named)
        {
            return named.IsIEnumerable() && named.TypeArguments.Any(IsDouble);
        }

        public static bool IsDictionary(this ITypeSymbol named)
        {
            return named.Name.Contains("Dictionary");
        }

        public static bool ImplementsIEnumerable(this ITypeSymbol symbol)
        {
            if (symbol is INamedTypeSymbol named && named.IsIEnumerable()) return true;
            return symbol.Interfaces.Length > 0 && symbol.Interfaces.Any(ImplementsIEnumerable);
        }

        public static bool IsIEnumerable(this INamedTypeSymbol named)
        {
            return named.Name.Contains("IEnumerable");
        }

        public static bool IsDouble(this ITypeSymbol symbol)
        {
            if (symbol.NullableAnnotation == NullableAnnotation.Annotated && symbol is INamedTypeSymbol named)
            {
                return named.TypeArguments.FirstOrDefault().SpecialType == SpecialType.System_Double;
            }
            return symbol.SpecialType == SpecialType.System_Double;
        }

        public static bool IsSingle(this ITypeSymbol symbol)
        {
            if (symbol.NullableAnnotation == NullableAnnotation.Annotated && symbol is INamedTypeSymbol named)
            {
                return named.TypeArguments.FirstOrDefault().SpecialType == SpecialType.System_Single;
            }
            return symbol.SpecialType == SpecialType.System_Single;
        }

        public static TypeSyntax AssignAndGetParent<T>(this T start, ISymbol symbol) where T : TypeSyntax
        {
            var s = symbol.ContainingSymbol;
            TypeSyntax current = start;
            while (true)
            {
                if (s is null || s is not INamespaceOrTypeSymbol namespaceOrTypeSymbol) return current;
                if (namespaceOrTypeSymbol.IsNamespace)
                {
                    var namespaceName = s.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.Omitted));
                    var parent = new NameSpaceContainerSyntax() { Name = namespaceName };
                    current.Parent = parent;
                    parent.Children.Add(current);
                    return parent;
                }
                else
                {
                    var typeDec = s.DeclaringSyntaxReferences.Select(x => x.GetSyntax()).OfType<TypeDeclarationSyntax>().First().Keyword.ValueText;
                    var typeName = s.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat);
                    var parent = new TypeContainerSyntax { Name = typeName, TypeDec = typeDec };
                    current.Parent = parent;
                    parent.Children.Add(current);
                    current = parent;
                }
                s = s.ContainingSymbol;
            }
        }

        public static IEnumerable<IPropertySymbol> GetProperties(this ITypeSymbol symbol) =>
            from property in symbol.GetMembers().OfType<IPropertySymbol>() select property;

        public static (string nspace, string displayString) ToFriendlyFormat(this ITypeSymbol typeSymbol)
        {
            if (typeSymbol.IsNamespace)
            {
                return (typeSymbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat), null);
            }
            var nspace = typeSymbol.ContainingNamespace.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat);
            var text = typeSymbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNotNullableReferenceTypeModifier).WithMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.UseSpecialTypes).WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.Omitted));
            if (text.StartsWith(nspace))
            {
                return (nspace, text.Replace(nspace, ""));
            }
            else
            {
                return (null, text);
            }
        }

        public static string ToNullableFullyQualifiedFormat(this ISymbol symbol)
        {
            var name = symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat
                .WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.Omitted)
                .AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier)
                .AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.UseSpecialTypes)
                .AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier));
            return name.Replace("System.IntPtr", "nint").Replace("System.UIntPtr", "nuint");
        }

        public static string ToFullyQualifiedFormat(this ISymbol symbol) => symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);

        public static string ToFullyMinimalFormat(this ISymbol symbol) => symbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat);

        public static ITypeSymbol GetSymbol(this GeneratorExecutionContext context, SyntaxNode node)
        {
            var model = context.Compilation.GetSemanticModel(node.SyntaxTree);
            return model.GetDeclaredSymbol(node, context.CancellationToken) as ITypeSymbol;
        }

#nullable enable
        public static bool Is(this AttributeData att, INamedTypeSymbol attSymbol)
        {
            if (att.AttributeClass is null) return false;
            return att.AttributeClass.Equals(attSymbol, SymbolEqualityComparer.Default);
        }

        public static bool HasAttribute(this ISymbol symbol, INamedTypeSymbol attSymbol)
        {
            if (symbol is null) return false;
            return symbol.GetAttributes().Any(x => x.Is(attSymbol));
        }

        public static AttributeData? GetAttribute(this ISymbol symbol, INamedTypeSymbol attribute) =>
            symbol.GetAttributes().FirstOrDefault(x => x.Is(attribute));

        public static INamedTypeSymbol? GetInterface(this IPropertySymbol property, string interfaceFqn)
        {
            if (property.IsGenericIenumerableLiteral() && property.Type is INamedTypeSymbol t) return t;
            return property.Type.AllInterfaces.FirstOrDefault(x => x.OriginalDefinition.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat) == interfaceFqn);
        }

        public static bool IsGenericIenumerableLiteral(this IPropertySymbol property)
        {
            return property.Type.IsGenericIenumerableLiteral();
        }

        public static bool IsGenericIenumerableLiteral(this ITypeSymbol type)
        {
            var name = type.OriginalDefinition.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
            return name == "global::System.Collections.Generic.IEnumerable<T>";
        }

        public static bool IsIDictionaryLiteral(this IPropertySymbol property)
        {
            return property.Type.IsIDictionaryLiteral();
        }

        public static bool IsIDictionaryLiteral(this ITypeSymbol type)
        {
            var name = type.OriginalDefinition.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
            return name == "global::System.Collections.Generic.IDictionary<TKey, TValue>";
        }

        public static ImmutableArray<ITypeSymbol>? GetIEnumerableTypeArguments(this IPropertySymbol property) =>
            property.GetInterface("global::System.Collections.Generic.IEnumerable<T>")?.TypeArguments;

        public static bool TryGetIDictionaryInterface(this IPropertySymbol property, out INamedTypeSymbol? dict, out ImmutableArray<ITypeSymbol> args)
        {
            return property.Type.TryGetIDictionaryInterface(out dict, out args);
        }

        public static bool TryGetIDictionaryInterface(this ITypeSymbol type, out INamedTypeSymbol? dict, out ImmutableArray<ITypeSymbol> args)
        {
            if (type.IsIDictionaryLiteral() && type is INamedTypeSymbol named)
            {
                dict = named;
                args = named.TypeArguments;
                return true;
            }
            var interfaces = type.AllInterfaces;
            if (interfaces.Length > 0)
            {
                foreach (var interf in interfaces)
                {
                    if (interf.TryGetIDictionaryInterface(out dict, out args))
                    {
                        return true;
                    }
                }
            }
            dict = null;
            args = new ImmutableArray<ITypeSymbol>();
            return false;
        }

        public static bool TryGetIEnumerableInterface(this IPropertySymbol property, out INamedTypeSymbol? dict, out ImmutableArray<ITypeSymbol> args)
        {
            return property.Type.TryGetIEnumerableInterface(out dict, out args);
        }

        public static bool TryGetIEnumerableInterface(this ITypeSymbol type, out INamedTypeSymbol? dict, out ImmutableArray<ITypeSymbol> args)
        {
            if (type.IsGenericIenumerableLiteral() && type is INamedTypeSymbol named)
            {
                dict = named;
                args = named.TypeArguments;
                return true;
            }
            var interfaces = type.AllInterfaces;
            if (interfaces.Length > 0)
            {
                foreach (var interf in interfaces)
                {
                    if (interf.TryGetIEnumerableInterface(out dict, out args))
                    {
                        return true;
                    }
                }
            }
            dict = null;
            args = new ImmutableArray<ITypeSymbol>();
            return false;
        }

        public static ImmutableArray<ITypeSymbol>? GetIDictionaryTypeArguments(this IPropertySymbol property) =>
            property.GetInterface("global::System.Collections.Generic.IDictionary<TKey, TValue>")?.TypeArguments;
#nullable disable
    }
}