using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace EMDD.KtEquatable.Core.EqualityComparers
{
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
