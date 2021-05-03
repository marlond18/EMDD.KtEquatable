using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace EMDD.KtEquatable.Core.EqualityComparers
{
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
#nullable restore
}
