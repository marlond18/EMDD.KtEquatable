
using Microsoft.CodeAnalysis;

namespace EMDD.KtEquatable.Syntax
{
    public class BaseType
    {
        public BaseType(INamedTypeSymbol symbol, INamedTypeSymbol equatable)
        {
            Name = symbol?.ToFullyQualifiedFormat();
            MarkedAsEquatable = symbol.HasAttribute(equatable);
            MarkedWithIEquatable = symbol.ImplementsIEquatable();
            IsAbstract = symbol.IsAbstract;
        }
        public bool IsBaseObject => Name == "object";
        public string Name { get; set; }
        public bool MarkedAsEquatable { get; set; }
        public bool MarkedWithIEquatable { get; set; }
        public bool IsAbstract { get; set; }
    }
}