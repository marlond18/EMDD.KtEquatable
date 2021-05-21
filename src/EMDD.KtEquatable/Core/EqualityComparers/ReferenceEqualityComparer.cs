using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EMDD.KtEquatable.Core.EqualityComparers
{
#nullable enable
    public class ReferenceEqualityComparer<T> : IEqualityComparer<T> where T : class?
    {
        public static ReferenceEqualityComparer<T> Default => new();

        public bool Equals(T? x, T? y) => ReferenceEquals(x, y);

#pragma warning disable RS1024 // Compare symbols correctly
        public int GetHashCode(T? obj) => RuntimeHelpers.GetHashCode(obj);
#pragma warning restore RS1024 // Compare symbols correctly
    }
#nullable restore
}