using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace EMDD.KtEquatable.Core.EqualityComparers
{
    public class SetEqualityComparer<TSource, T> : EnumerableEqualityComparer<TSource?, T> where TSource: IEnumerable<T>?
    {
        public SetEqualityComparer(IEqualityComparer<T> valueComparer) : base(valueComparer)
        {
        }

        public static SetEqualityComparer<TSource?,T> Default { get; } = new(EqualityComparer<T>.Default);

        public override bool Equals(TSource? x, TSource? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            if (x is ISet<T> xSet) return xSet.SetEquals(y);
            if (y is ISet<T> ySet) return ySet.SetEquals(x);
            return x.All(xVal => y.Any(yVal => _valueComparer.Equals(xVal, yVal))) && y.All(yVal => x.Any(xVal => _valueComparer.Equals(xVal, yVal)));
        }
        public override int GetHashCode(TSource? obj) => 0;
    }
#nullable restore
}
