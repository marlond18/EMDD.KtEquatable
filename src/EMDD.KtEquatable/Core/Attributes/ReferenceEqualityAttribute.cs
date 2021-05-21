using System;

namespace EMDD.KtEquatable.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class ReferenceEqualityAttribute : Attribute
    {
    }
}