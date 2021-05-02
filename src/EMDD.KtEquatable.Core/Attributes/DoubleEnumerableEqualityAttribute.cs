using System;

namespace EMDD.KtEquatable.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DoubleEnumerableEqualityAttribute : Attribute
    {
        public int Precision { get; set; } = 10;

        public bool Ordered { get; set; }

        public bool IsSet { get; set; }
    }
}