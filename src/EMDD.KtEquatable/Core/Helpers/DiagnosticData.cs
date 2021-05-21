using EMDD.KtEquatable.Core.Attributes;
using EMDD.KtEquatable.Syntax;

using Microsoft.CodeAnalysis;
namespace EMDD.KtEquatable.Core
{
#nullable enable
    public static class DiagnosticData
    {
        public const string Category = "Usage";

        public delegate (string id, string title, string desc, DiagnosticSeverity severity) TypeInfo<T>(T? symbol) where T : ISymbol;

        public static DiagnosticDescriptor Create<T>(TypeInfo<T> InfoGen, T? symbol) where T : ISymbol
        {
            var (id, title, desc, severity) = InfoGen(symbol);
            return new DiagnosticDescriptor(id, title, desc, Category, severity, true);
        }

        public static Diagnostic Create<T>(TypeInfo<T> InfoGen, T? symbol, SyntaxNode node) where T : ISymbol
        {
            var (id, title, desc, severity) = InfoGen(symbol);
            return Diagnostic.Create(new DiagnosticDescriptor(id, title, desc, Category, severity, true), node.GetLocation());
        }

        public static TypeInfo<ITypeSymbol> StaticClass = (s) =>
        (
            "KTEQG1",
            "Static classes can't be marked as Equatable",
            $"{s?.ToFullyQualifiedFormat()} is static and can't implement IEquatable<{s?.ToFullyQualifiedFormat()}, hence can' be   marked with EquatableAttribute. Code not generated.",
            DiagnosticSeverity.Error
        );

        public static TypeInfo<ITypeSymbol> RedundantIEquatable = (s) =>
        (
            "KTEQG2",
            "Redundant IEquatable",
            $"Unable to generate code for {s?.ToFullyQualifiedFormat()} since it already implements IEquatable  {s?.ToFullyQualifiedFormat()}.",
            DiagnosticSeverity.Warning
        );

        public static TypeInfo<ITypeSymbol> BaseNonIEquatable = (s) =>
        (
            "KTEQG3",
            "Base does not implementIEquatable",
            $"{s?.ToFullyQualifiedFormat()} derives from {s?.BaseType.ToFullyQualifiedFormat()} which does not implementIEquatable< {s?.BaseType?.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat)}>. Code cannot begenerated.",
            DiagnosticSeverity.Warning
        );

        public static TypeInfo<ITypeSymbol> TypeNotSupported = (s) =>
        (
            "KtEQG4",
            "Type is not supported.",
            $"{s?.BaseType.ToFullyQualifiedFormat()} is not supported for Equatable code generation.",
            DiagnosticSeverity.Warning
        );

        public static TypeInfo<IPropertySymbol> FloatingPointPrecisionLessZero = (s) =>
        (
            "KtEQG6",
            "Precision is less than 0.",
            $"The Precision parameter of the Attribute on {s?.ToFullyQualifiedFormat()} can't be less than zero. Default Equality Comparer will be used.",
            DiagnosticSeverity.Error
        );

        public static TypeInfo<IPropertySymbol> WrongTypeApplication = (s) =>
        (
            "KtEQG7",
            "Attribute and property type mismatch.",
            $"{s?.ToFullyQualifiedFormat()} is not compatible with its attribute. Attribute will be ignored.",
            DiagnosticSeverity.Warning
        );

        public static TypeInfo<IPropertySymbol> DictionaryCantBeOrderedType = (s) =>
          (
              "KtEQG8",
              $"Dictionary Cannot be Marked with {typeof(EnumerableEqualityAttribute).Name} with {nameof(EnumerableOrderType.Ordered)}.",
              $"{s?.ToFullyQualifiedFormat()} is a dictionary type and should not be marked with {typeof(EnumerableEqualityAttribute).Name} with {nameof(EnumerableOrderType.Ordered)}.",
              DiagnosticSeverity.Warning
          );

        public static TypeInfo<IPropertySymbol> DictionaryCantBeSetType = (s) =>
          (
              "KtEQG9",
              $"Dictionary Cannot be Marked with {typeof(EnumerableEqualityAttribute).Name} with {nameof(EnumerableOrderType.Set)}.",
              $"{s?.ToFullyQualifiedFormat()} is a dictionary type and should not be marked with {typeof(EnumerableEqualityAttribute).Name} with {nameof(EnumerableOrderType.Set)}.",
              DiagnosticSeverity.Warning
          );

        public static TypeInfo<IPropertySymbol> OtherAttributesIgnored = (s) =>
          (
              "KtEQG10",
              $"Multiple Attributes with {typeof(IgnoreEqualityAttribute).Name}.",
              $"{s?.ToFullyQualifiedFormat()} is marked with multiple attributes together with an {typeof(IgnoreEqualityAttribute).Name}. {typeof(IgnoreEqualityAttribute).Name} will govern.",
              DiagnosticSeverity.Warning
          );

        public static TypeInfo<IPropertySymbol> CantIncludeIndexer = (s) =>
          (
              "KtEQG11",
              "Property Is An Indexer.",
              $"{s?.ToFullyQualifiedFormat()} is an indexer and should not be marked with any equality attributes",
              DiagnosticSeverity.Warning
          );

        public static TypeInfo<IPropertySymbol> PropertyIsWriteOnly = (s) =>
        (
            "KtEQG12",
            "Property Is An WriteOnly.",
            $"{s?.ToFullyQualifiedFormat()} is writeonly and will be ignored. I should not be marked with any attributes.",
            DiagnosticSeverity.Warning
        );

        public static TypeInfo<IPropertySymbol> ReferenceEqualityMustBeClass = (s) =>
        (
            "KtEQG13",
            "Non-Class Property Marked as ReferenceEquality",
            $"{s?.ToFullyQualifiedFormat()} has been marked with {typeof(ReferenceEqualityAttribute).FullName} despite not being a class. Code was not generated.",
            DiagnosticSeverity.Warning
        );

        public static TypeInfo<IPropertySymbol> FloatingPointPrecisionIsMissing = (s) =>
        (
            "KtEQG14",
            "Precision is missing.",
            $"The Precision parameter of the Attribute on {s?.ToFullyQualifiedFormat()} Is missing. Default    Equality Comparer will be used.",
            DiagnosticSeverity.Warning
        );

        public const string UnExpectedErrorId = "KtEqG20";
    }
#nullable restore
}