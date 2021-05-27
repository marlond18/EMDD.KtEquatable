using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace EMDD.KtEquatable.Core.EqualityComparers
{
    public class UnorderedEqualityComparer<TSource,T> : EnumerableEqualityComparer<TSource?, T> where TSource:IEnumerable<T>?
    {
        public UnorderedEqualityComparer(IEqualityComparer<T> valueComparer) : base(valueComparer)
        {
        }

        public static UnorderedEqualityComparer<TSource?,T> Default { get; } = new(EqualityComparer<T>.Default);

        public override bool Equals(TSource? x, TSource? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            if (x.Count() != y.Count()) return false;
            return x.All(xVal => y.Contains(xVal, _valueComparer)) && y.All(yVal => x.Contains(yVal, _valueComparer));
        }

        public override int GetHashCode(TSource? obj)
        {
            return (obj?.Aggregate(0, (hashCode, t) => t is null ? hashCode : hashCode ^ (_valueComparer.GetHashCode(t) & 0x7FFFFFFF))) ?? 0;
        }
    }
#nullable restore
}