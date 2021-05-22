using System;
using System.Collections.Generic;

namespace EMDD.KtEquatable.Core.EqualityComparers
{
    public class FloatingPointEqualityComparer : IEqualityComparer<double>
    {
        private readonly int precision;

        public FloatingPointEqualityComparer(int precision)
        {
            this.precision = precision;
        }

        public bool Equals(double x, double y)
        {
            return x.NearEquals(y, precision);
        }

        public int GetHashCode(double obj)
        {
            return obj.GetDoubleHashCode(precision);
        }
    }
}
