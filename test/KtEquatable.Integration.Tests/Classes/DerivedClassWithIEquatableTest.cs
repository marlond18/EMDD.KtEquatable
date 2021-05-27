
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMDD.KtEquatable.Core;
using EMDD.KtEquatable.Core.Attributes;
using System;
using EMDD.KtEquatable.Core.EqualityComparers;
using System.Collections.Generic;
using KtEquatable.Tests;
using System.Linq;

namespace Tests.Classes
{
    //internal class UnorderedEqualityComparer<TSource, T> : EnumerableEqualityComparer<TSource?, T> where TSource : IEnumerable<T>?
    //{
    //    public UnorderedEqualityComparer(IEqualityComparer<T> valueComparer) : base(valueComparer)
    //    {
    //    }

    //    public static UnorderedEqualityComparer<TSource?, T> Default { get; } = new(EqualityComparer<T>.Default);

    //    public override bool Equals(TSource? x, TSource? y)
    //    {
    //        if (ReferenceEquals(x, y)) return true;
    //        if (x is null || y is null) return false;
    //        if (x.Count() != y.Count()) return false;
    //        return x.All(xVal => y.Contains(xVal, _valueComparer)) && y.All(yVal => x.Contains(yVal, _valueComparer));
    //    }

    //    public override int GetHashCode(TSource? obj)
    //    {
    //        return (obj?.Aggregate(0, (hashCode, t) => t is null ? hashCode : hashCode ^ (_valueComparer.GetHashCode(t) & 0x7FFFFFFF))) ?? 0;
    //    }
    //}

    [TestClass]
    public partial class DerivedClassWithIEquatableTest
    {
        public class Person : System.IEquatable<Person>
        {
            public string? Name { get; set; }
            public int Age { get; set; }

            public bool Equals(Person? other)
            {
                return false;
            }

            public override bool Equals(object? obj)
            {
                return Equals(obj as Person);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Name, Age);
            }
        }

        [Equatable]
        public partial class Employee : Person
        {
            [FloatingPointEquality(20)]
            public double Salary { get; set; }
        }

        [TestClass]
        public class FailsDueToBaseTests : EqualityTestWithOperatorBase
        {
            public override bool MustBeEqual => false;

            public override object Data1() => new Employee() { Name = "Juan", Age = 20, Salary = 60000 };

            public override object Data2() => new Employee() { Name = "Juan", Age = 20, Salary = 60000 };

            public override bool EqualsOperator(object value1, object value2) => (Employee)value1 == (Employee)value2;

            public override bool NotEqualsOperator(object value1, object value2) => (Employee)value1 != (Employee)value2;
        }
    }
}
