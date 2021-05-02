using System;

namespace EMDD.KtEquatable.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FloatingPointEqualityAttribute : Attribute
    {
        public int Precision { get; set; } = 10;
    }
}