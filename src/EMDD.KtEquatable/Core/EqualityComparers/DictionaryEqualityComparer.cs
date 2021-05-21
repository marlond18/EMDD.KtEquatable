using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace EMDD.KtEquatable.Core.EqualityComparers
{
    public abstract class EnumerableEqualityComparer<T, TValue> : IEqualityComparer<T?> where T : IEnumerable?
    {
        protected readonly IEqualityComparer<TValue> _valueComparer;

        protected EnumerableEqualityComparer(IEqualityComparer<TValue> valueComparer)
        {
            _valueComparer = valueComparer;
        }

        public abstract bool Equals(T? x, T? y);
        public abstract int GetHashCode(T? obj);
    }

    public class DictionaryEqualityComparer<TSource, TKey, TValue> : EnumerableEqualityComparer<TSource?, TValue> where TSource : IDictionary<TKey, TValue>?
    {
        public DictionaryEqualityComparer(IEqualityComparer<TValue> valueComparer) : base(valueComparer)
        {
        }

        public static DictionaryEqualityComparer<TSource?, TKey, TValue> Default => new(EqualityComparer<TValue>.Default);

        public override bool Equals(TSource? x, TSource? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x == null || y == null) return false;
            if (x.Count != y.Count) return false;
            foreach (var pair in x)
            {
                if (!y.TryGetValue(pair.Key, out var yValue)) return false;
                if (!_valueComparer.Equals(pair.Value, yValue)) return false;
            }
            return true;
        }

        public override int GetHashCode(TSource? obj)
        {
            return (obj?.Aggregate(0, (hashCode, t) => hashCode ^ ((EqualityComparer<TKey>.Default.GetHashCode(t.Key) + _valueComparer.GetHashCode(t.Value)) & 0x7FFFFFFF))) ?? 0;
        }
    }
#nullable restore
}
