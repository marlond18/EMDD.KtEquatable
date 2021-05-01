namespace EMDD.KtSourceGen.KtEquatable.Syntax.Property
{
    public class PropertySetEquality : PropertyHasCustomComparer
    {
        public override string ComparerName => "SetEqualityComparer";

        public override string Code => $@"    public class {ComparerName}<T> : IEqualityComparer<IEnumerable<T>>
    {{
        private static readonly EqualityComparer<T> _equalityComparer = EqualityComparer<T>.Default;

        public static {ComparerName}<T> Default {{ get; }} = new {ComparerName}<T>();

        public bool Equals(IEnumerable<T>? x, IEnumerable<T>? y)
        {{
            if (ReferenceEquals(x, y)) return true;
            if (x == null || y == null) return false;
            if (x is ISet<T> xSet) return xSet.SetEquals(y);
            if (y is ISet<T> ySet) return ySet.SetEquals(x);
            return x.All(xVal => y.Any(yVal => _equalityComparer.Equals(xVal, yVal))) && y.All(yVal => x.Any(xVal => _equalityComparer.Equals(xVal, yVal)));
        }}

        public int GetHashCode(IEnumerable<T>? obj) => 0;
    }}";
    }
}
