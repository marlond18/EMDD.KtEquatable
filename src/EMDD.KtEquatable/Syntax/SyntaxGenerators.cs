
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace EMDD.KtSourceGen.KtEquatable.Syntax
{
    public static class SyntaxGenerators
    {
        public static (string name, string baseType) GetDeclarationNames(this  ITypeSymbol symbol)
        {
            var typeName = symbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat);
            var baseTypeName = symbol.BaseType?.ToFullyQualifiedFormat();
            return (typeName, baseTypeName);
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

        public static string ToNullableFullyQualifiedFormat(this ISymbol symbol) =>
            symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier));

        public static string ToFullyQualifiedFormat(this ISymbol symbol) => symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);

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

        public static INamedTypeSymbol? GetInterface(this IPropertySymbol property, string interfaceFqn) =>
            property.Type.AllInterfaces.FirstOrDefault(x => x.OriginalDefinition.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat) == interfaceFqn);

        public static ImmutableArray<ITypeSymbol>? GetIEnumerableTypeArguments(this IPropertySymbol property) =>
            property.GetInterface("global::System.Collections.Generic.IEnumerable<T>")?.TypeArguments;

        public static ImmutableArray<ITypeSymbol>? GetIDictionaryTypeArguments(this IPropertySymbol property) =>
            property.GetInterface("global::System.Collections.Generic.IDictionary<TKey, TValue>")?.TypeArguments;
#nullable disable
    }
}
