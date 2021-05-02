
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMDD.KtEquatable.Core;
using EMDD.KtEquatable.Core.Attributes;

namespace KtEquatable.Tests
{
    [TestClass]
    public partial class DerivedClassNoAttributeTest
    {
        public class Person
        {
            public string? Name { get; set; }
            public int Age { get; set; }
        }

        [Equatable]
        public partial class Employee : Person
        {
            [FloatingPointEquality(Precision = 20)]
            public double Salary { get; set; }
        }

        [TestClass]
        public class EqualsTests : EqualityTestWithOperatorBase
        {
            public override bool MustBeEqual => true;

            public override object Data1() => new Employee() { Name = "Juan", Age = 20, Salary = 60000 };

            public override object Data2() => new Employee() { Name = "Juan", Age = 20, Salary = 60000 };

            public override bool EqualsOperator(object value1, object value2) => (Employee)value1 == (Employee)value2;

            public override bool NotEqualsOperator(object value1, object value2) => (Employee)value1 != (Employee)value2;
        }

        [TestClass]
        public class EqualsBaseIgnoreTests : EqualityTestWithOperatorBase
        {
            public override bool MustBeEqual => false;

            public override object Data1() => new Employee() { Name = "Juan2", Age = 20, Salary = 60000 };

            public override object Data2() => new Employee() { Name = "Juan", Age = 20, Salary = 60000 };

            public override bool EqualsOperator(object value1, object value2) => (Employee)value1 == (Employee)value2;

            public override bool NotEqualsOperator(object value1, object value2) => (Employee)value1 != (Employee)value2;
        }
    }
}