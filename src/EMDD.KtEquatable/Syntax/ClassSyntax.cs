using EMDD.KtEquatable.Core;

using System.Collections.Generic;
using System.Linq;

using static EMDD.KtEquatable.Core.CoreHelpers;

namespace EMDD.KtSourceGen.KtEquatable.Syntax
{
    public class ClassSyntax : TypeSyntaxWithProps
    {
        public ClassSyntax()
        {
            var d = new object();
            var e = new object();
            if (ReferenceEquals(d, e)) return;
            if (d is null) return;
        }

        public override string BuildString()
        {
            return $@"partial class {Name} : IEquatable<{Name}> 
{{
#nullable enable
    {EqualsOperatorCodeComment.IndentNextLines(1)}
    {GeneratedCodeAttributeDeclaration.IndentNextLines(1)}
    public static bool operator ==({Name}? left, {Name}? right) =>
        EqualityComparer<{Name}>.Default.Equals(left, right);

    {NotEqualsOperatorCodeComment.IndentNextLines(1)}
    {GeneratedCodeAttributeDeclaration.IndentNextLines(1)}
    public static bool operator !=({Name}? left, {Name}? right) =>
        !(left == right);

    {InheritDocComment}
    {GeneratedCodeAttributeDeclaration.IndentNextLines(1)}
    public override bool Equals(object? obj) =>
        Equals(obj as {Name});

    {InheritDocComment}
    {GeneratedCodeAttributeDeclaration.IndentNextLines(1)}
    public bool Equals({Name}? other) 
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

        private IEnumerable<string> GetEqualitySyntax() => new[]{UseBaseTypeImpl
        ? $"base.Equals(other as {BaseName})"
        : "this.GetType() == other.GetType()"}
        .Concat(PropertiesSytax.Select(p => p.EqualityString()));
    }
}