using EMDD.KtSourceGen.KtEquatable.Syntax.Property;

using System.Collections.Generic;

namespace EMDD.KtSourceGen.KtEquatable.Syntax
{
    public abstract class TypeSyntaxWithProps : TypeSyntax
    {
        public string Name { get; set; }

        public string BaseName { get; set; }

        public bool IsDerived => BaseName != "object";

        public bool BaseImplementsEquatable { get; set; }

        public bool UseBaseTypeImpl => IsDerived && BaseImplementsEquatable;

        public List<PropertyDefaultEquality> PropertiesSytax { get; set; } = new List<PropertyDefaultEquality>();
    }
}