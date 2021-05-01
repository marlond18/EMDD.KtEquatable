using System.Collections.Generic;
using System.Linq;

using static EMDD.KtSourceGen.KtEquatable.Core.CoreHelpers;

namespace EMDD.KtSourceGen.KtEquatable.Syntax
{
    public class RecordSyntax : TypeSyntaxWithProps
    {
        public string TypeDec { get; set; }

        public bool IsSealed { get; set; }

        public override string BuildString()
        {
            return $@"partial {TypeDec} {Name}
{{
#nullable enable
    {EqualsOperatorCodeComment.IndentNextLines(1)}
    {GeneratedCodeAttributeDeclaration.IndentNextLines(1)}
    public {(IsSealed ? "" : "virtual")} bool Equals({Name}? other) 
    {{
        {string.Join("\n", GetEqualitySyntax()).IndentNextLines(2)};
    }}

    public override int GetHashCode() 
    {{
        var hashCode = new global::System.HashCode();
        {(BaseType == "object" ? "hashCode.Add(this.GetType());" : "hashCode.Add(base.GetHashCode());")}
        {string.Join("\n", PropertiesSytax.Select(p => p.HashCodeString() + ";")).IndentNextLines(2)}
        return hashCode.ToHashCode();
    }}
#nullable restore
}}";
        }

        private IEnumerable<string> GetEqualitySyntax() => new[]{BaseType == "object"
        ? "return !ReferenceEquals(other, null) && EqualityContract == other.EqualityContract"
        : $"return base.Equals(other as {BaseType})"}
        .Concat(PropertiesSytax.Select(p => p.EqualityString()));
    }
}
