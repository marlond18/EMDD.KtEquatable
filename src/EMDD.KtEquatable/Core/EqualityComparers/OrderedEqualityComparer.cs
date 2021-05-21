using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace EMDD.KtEquatable.Core.EqualityComparers
{
    public class OrderedEqualityComparer<TSource,T> : EnumerableEqualityComparer<TSource?, T> where TSource:IEnumerable<T>?
    {
        public OrderedEqualityComparer(IEqualityComparer<T> valueComparer) : base(valueComparer)
        {
        }

        public static OrderedEqualityComparer<TSource?,T> Default { get; } = new(EqualityComparer<T>.Default);

        public override bool Equals(TSource? x, TSource? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return x.SequenceEqual(y, _valueComparer);
        }

        public override int GetHashCode(TSource? obj)
        {
            if (obj == null) return 0;
            var hashCode = new HashCode();
            foreach (var item in obj)
            {
                hashCode.Add(item, _valueComparer);
            }
            return hashCode.ToHashCode();
        }
    }
#nullable restore
}
