using EMDD.KtEquatable.Core;

using System.Collections.Generic;
using System.Linq;

using static EMDD.KtEquatable.Core.CoreHelpers;

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
        if (ReferenceEquals(this, other)) return true;
        if (other is null ||this is null) return false;
        return {string.Join("\n", GetEqualitySyntax()).IndentNextLines(2)};
    }}

    public override int GetHashCode() 
    {{
        var hashCode = new HashCode();
        {(UseBaseTypeImpl ? "hashCode.Add(base.GetHashCode());" : "hashCode.Add(this.GetType());")}
        {string.Join("\n", PropertiesSytax.Select(p => p.HashCodeString() + ";")).IndentNextLines(2)}
        return hashCode.ToHashCode();
    }}
#nullable restore
}}";
        }

        private IEnumerable<string> GetEqualitySyntax() => new[]{ UseBaseTypeImpl
        ? $"base.Equals(other as {BaseName})"
        : "EqualityContract == other.EqualityContract"}
        .Concat(PropertiesSytax.Select(p => p.EqualityString()));
    }
}
