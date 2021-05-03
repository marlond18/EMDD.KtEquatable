using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace EMDD.KtEquatable.Core.EqualityComparers
{
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
#nullable restore
}
