using EMDD.KtEquatable.Core.Attributes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KtEquatable.Tests.Classes
{
    [TestClass]
    public partial class NoAttributes
    {
        [Equatable]
        public partial class TempData
        {
            public int Age { get; set; }

            public string? Name { get; set; }
        }

        [Equatable]
        public partial class TempData2
        {
            public int Age { get; set; }

            public string? Name { get; set; }
        }

        [TestClass]
        public class EqualTest : EqualityTestWithOperatorBase
        {
            public override bool Expected => true;

            public override object Factory1() => new TempData { Name = "Juan", Age = 21 };

            public override object Factory2() => new TempData { Name = "Juan", Age = 21 };

            public override bool EqualsOperator(object value1, object value2) => (TempData)value1 == (TempData)value2;

            public override bool NotEqualsOperator(object value1, object value2) => (TempData)value1 != (TempData)value2;
        }

        [TestClass]
        public class NotEqualTest : EqualityTestWithOperatorBase
        {
            public override bool Expected => false;

            public override object Factory1() => new TempData { Name = "Juan", Age = 21 };

            public override object Factory2() => new TempData { Name = "Juan", Age = 22 };

            public override bool EqualsOperator(object value1, object value2) => (TempData)value1 == (TempData)value2;

            public override bool NotEqualsOperator(object value1, object value2) => (TempData)value1 != (TempData)value2;
        }

        [TestClass]
        public class NotEqualTestDifferentType : EqualityTestBase
        {
            public override bool Expected => false;

            public override object Factory1() => new TempData { Name = "Juan", Age = 21 };

            public override object Factory2() => new TempData2 { Name = "Juan", Age = 21 };
        }

        [TestClass]
        public class NotEqualTestSameReference : EqualityTestBase
        {
            public override bool Expected => true;

            public static object Main => new TempData { Name = "Juan", Age = 21 };

            public override object Factory1() => Main;

            public override object Factory2() => Main;
        }
    }
}