using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace EMDD.KtEquatable.Core.EqualityComparers
{
    public class DictionaryEqualityComparer<TKey, TValue> : IEqualityComparer<IDictionary<TKey, TValue>>
    {
        public static DictionaryEqualityComparer<TKey, TValue> Default => new();

        public bool Equals(IDictionary<TKey, TValue>? x, IDictionary<TKey, TValue>? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x == null || y == null) return false;
            if (x.Count != y.Count) return false;
            foreach (var pair in x)
            {
                if (!y.TryGetValue(pair.Key, out var yValue)) return false;
                if (!EqualityComparer<TValue>.Default.Equals(pair.Value, yValue)) return false;
            }
            return true;
        }

        public int GetHashCode(IDictionary<TKey, TValue>? obj) =>
            (obj?.Aggregate(0, (hashCode, t) => hashCode ^ (EqualityComparer<KeyValuePair<TKey, TValue>>.Default.GetHashCode(t) & 0x7FFFFFFF))) ?? 0;
    }
#nullable restore
}
