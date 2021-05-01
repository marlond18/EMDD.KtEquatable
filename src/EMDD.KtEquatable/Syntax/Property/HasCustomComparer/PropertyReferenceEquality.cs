namespace EMDD.KtSourceGen.KtEquatable.Syntax.Property
{
    public class PropertyReferenceEquality : PropertyHasCustomComparer
    {
        public override string ComparerName => "ReferenceEqualityComparer";

        public override string Code => $@"    public class {ComparerName}<T> : IEqualityComparer<T> where T : class
    {{
        public static {ComparerName}<T> Default {{ get; }} = new {ComparerName}<T>();

        public bool Equals(T? x, T? y) => ReferenceEquals(x, y);

        public int GetHashCode(T? obj) => RuntimeHelpers.GetHashCode(obj);
    }}";
    }
}