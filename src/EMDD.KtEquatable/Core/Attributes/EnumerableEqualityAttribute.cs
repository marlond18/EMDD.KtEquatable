using System;

namespace EMDD.KtEquatable.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class EnumerableEqualityAttribute : Attribute
    {
        public EnumerableEqualityAttribute(EnumerableOrderType orderType = EnumerableOrderType.Unordered)
        {
            OrderType = orderType;
        }

        public EnumerableOrderType OrderType { get; }
    }

    public enum EnumerableOrderType
    {
        Unordered = 0,
        Ordered = 1,
        Set = 2,
    }
}