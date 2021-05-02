
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMDD.KtEquatable.Core;
using EMDD.KtEquatable.Core.Attributes;

namespace KtEquatable.Tests
{
    [TestClass]
    public partial class DerivedClassWithIEquatableTest
    {
        public class Person: System.IEquatable<Person>
        {
            public string? Name { get; set; }
            public int Age { get; set; }

            public bool Equals(Person? other)
            {
                return false;
            }
        }

        [Equatable]
        public partial class Employee : Person
        {
            [FloatingPointEquality(Precision = 20)]
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
