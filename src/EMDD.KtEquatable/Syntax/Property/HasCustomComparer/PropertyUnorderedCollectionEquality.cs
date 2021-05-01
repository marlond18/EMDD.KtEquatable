namespace EMDD.KtSourceGen.KtEquatable.Syntax.Property
{
    public class PropertyUnorderedCollectionEquality : PropertyHasCustomComparer
    {
        public override string ComparerName => "UnorderedEqualityComparer";

        public override string Code => $@"    public class {ComparerName}<T> : IEqualityComparer<IEnumerable<T>>
    {{
        private static readonly IEqualityComparer<T> EqualityComparer = EqualityComparer<T>.Default;

        public static IEqualityComparer<IEnumerable<T>> Default {{ get; }} = new {ComparerName}<T>();

        public bool Equals(IEnumerable<T>? x, IEnumerable<T>? y)
        {{
            if (ReferenceEquals(x, y)) return true;
            if (x == null || y == null) return false;
            if (x is ICollection<T> xCollection && y is ICollection<T> yCollection && xCollection.Count != yCollection.Count) return false;
            var cnt = new Dictionary<T, int>(EqualityComparer);
            foreach (var s in x)
            {{
                cnt[s] = (cnt.TryGetValue(s, out var v) ? v : 0) + 1;
            }}
            foreach (var s in y)
            {{
                if (!cnt.ContainsKey(s)) return false;
                cnt[s]--;
            }}
            return cnt.Values.All(c => c == 0);
        }}

        public int GetHashCode(IEnumerable<T>? obj)
        {{
            var hashCode = 0;
            if (obj == null) return hashCode;
            foreach (var t in obj)
            {{
                if (t != null)
                {{
                    hashCode ^= EqualityComparer.GetHashCode(t) & 0x7FFFFFFF;
                }}
            }}
            return hashCode;
        }}
    }}";
    }
}
