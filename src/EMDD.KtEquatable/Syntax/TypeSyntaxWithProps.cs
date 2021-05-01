using EMDD.KtSourceGen.KtEquatable.Syntax.Property;

using System.Collections.Generic;
using System.Linq;

using static EMDD.KtSourceGen.KtEquatable.Core.CoreHelpers;

namespace EMDD.KtSourceGen.KtEquatable.Syntax
{
    public abstract class TypeSyntaxWithProps : TypeSyntax
    {
        public string Name { get; set; }

        public string BaseType { get; set; }

        public List<PropertyDefaultEquality> PropertiesSytax { get; set; } = new List<PropertyDefaultEquality>();
    }
}