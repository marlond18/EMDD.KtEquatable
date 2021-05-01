namespace EMDD.KtSourceGen.KtEquatable.Syntax.Property
{
    public class PropertyDictionaryEquality : PropertyHasCustomComparer
    {
        public override string ComparerName => "DictionaryEqualityComparer";

        public override string Code => $@"    public class {ComparerName}<TKey, TValue> : IEqualityComparer<IDictionary<TKey, TValue>>
    {{
        private static readonly EqualityComparer<TValue> ValueEqualityComparer = EqualityComparer<TValue>.Default;

        private static readonly EqualityComparer<KeyValuePair<TKey, TValue>> EqualityComparer = EqualityComparer<KeyValuePair<TKey, TValue>>.Default;

        public static {ComparerName}<TKey, TValue> Default {{ get; }} = new {ComparerName}<TKey, TValue>();

        public bool Equals(IDictionary<TKey, TValue>? x, IDictionary<TKey, TValue>? y)
        {{
            if (ReferenceEquals(x, y)) return true;
            if (x == null || y == null) return false;
            if (x.Count != y.Count) return false;
            foreach (var pair in x)
            {{
                if (!y.TryGetValue(pair.Key, out var yValue)) return false;
                if (!ValueEqualityComparer.Equals(pair.Value, yValue)) return false;
            }}
            return true;
        }}

        public int GetHashCode(IDictionary<TKey, TValue>? obj)
        {{
            var hashCode = 0;
            if (obj == null) return hashCode;
            foreach (var t in obj)
            {{
                hashCode ^= EqualityComparer.GetHashCode(t) & 0x7FFFFFFF;
            }}
            return hashCode;
        }}
    }}";
    }
}
