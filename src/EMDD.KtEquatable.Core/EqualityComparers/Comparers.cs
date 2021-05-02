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

    public class OrderedEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public static OrderedEqualityComparer<T> Default { get; } = new OrderedEqualityComparer<T>();
        public bool Equals(IEnumerable<T>? x, IEnumerable<T>? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return x.SequenceEqual(y);
        }

        public int GetHashCode(IEnumerable<T>? obj)
        {
            if (obj == null) return 0;
            var hashCode = new HashCode();
            foreach (var item in obj)
            {
                hashCode.Add(item, EqualityComparer<T>.Default);
            }
            return hashCode.ToHashCode();
        }
    }

    public class ReferenceEqualityComparer<T> : IEqualityComparer<T> where T : class
    {
        public static ReferenceEqualityComparer<T> Default => new();

        public bool Equals(T? x, T? y) => ReferenceEquals(x, y);

        public int GetHashCode(T? obj) => RuntimeHelpers.GetHashCode(obj);
    }

    public class SetEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public static SetEqualityComparer<T> Default => new();

        public bool Equals(IEnumerable<T>? x, IEnumerable<T>? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            if (x is ISet<T> xSet) return xSet.SetEquals(y);
            if (y is ISet<T> ySet) return ySet.SetEquals(x);
            return x.All(xVal => y.Any(yVal => EqualityComparer<T>.Default.Equals(xVal, yVal))) && y.All(yVal => x.Any(xVal => EqualityComparer<T>.Default.Equals(xVal, yVal)));
        }
        public int GetHashCode(IEnumerable<T>? obj) => 0;
    }
    public class UnorderedEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public static UnorderedEqualityComparer<T> Default => new();

        public bool Equals(IEnumerable<T>? x, IEnumerable<T>? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            if (x.Count() != y.Count()) return false;
            return x.All(xVal => y.Contains(xVal)) && y.All(yVal => x.Contains(yVal));
        }

        public int GetHashCode(IEnumerable<T>? obj)
        {
            return (obj?.Aggregate(0, (hashCode, t) => t is null ? hashCode : hashCode ^ (EqualityComparer<T>.Default.GetHashCode(t) & 0x7FFFFFFF))) ?? 0;
        }
    }
#nullable restore
}
