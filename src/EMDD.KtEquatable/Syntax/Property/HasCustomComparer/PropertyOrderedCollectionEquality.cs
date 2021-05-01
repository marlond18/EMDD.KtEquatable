namespace EMDD.KtSourceGen.KtEquatable.Syntax.Property
{
    public class PropertyOrderedCollectionEquality : PropertyHasCustomComparer
    {
        public override string ComparerName => "OrderedEqualityComparer";

        public override string Code => $@"    public class {ComparerName}<T> : IEqualityComparer<IEnumerable<T>>
    {{
        private static readonly EqualityComparer<T> EqualityComparer = EqualityComparer<T>.Default;

        public static {ComparerName}<T> Default {{ get; }} = new {ComparerName}<T>();

        public bool Equals(IEnumerable<T>? x, IEnumerable<T>? y)
        {{
            if (ReferenceEquals(x, y)) return true;
            if (x == null || y == null) return false;
            return x.SequenceEqual(y);
        }}

        public int GetHashCode(IEnumerable<T>? obj)
        {{
            if (obj == null) return 0;
            var hashCode = new HashCode();
            foreach (var item in obj)
            {{
                hashCode.Add(item, EqualityComparer);
            }}
            return hashCode.ToHashCode();
        }}
    }}";
    }
}
