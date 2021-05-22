using System;
using System.Collections.Generic;

namespace EMDD.KtEquatable.Core.EqualityComparers
{
    public class FloatingPointEqualityComparer : IEqualityComparer<double?>
    {
        private readonly int precision;

        public FloatingPointEqualityComparer(int precision)
        {
            this.precision = precision;
        }

        public bool Equals(double? x, double? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return x.Value.NearEquals(y.Value, precision);
        }

        public int GetHashCode(double? obj)
        {
            return obj is null? obj.GetHashCode(): obj.Value.GetDoubleHashCode(precision);
        }
    }
}
