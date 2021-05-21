using System;

namespace EMDD.KtEquatable.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false,Inherited =false)]
    public class FloatingPointEqualityAttribute : Attribute
    {
        public FloatingPointEqualityAttribute(int precision = 10)
        {
            Precision = precision;
        }

        public int Precision { get; }
    }
}