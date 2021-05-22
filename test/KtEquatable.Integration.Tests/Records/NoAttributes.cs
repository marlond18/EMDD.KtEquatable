
using EMDD.KtEquatable.Core.Attributes;

using KtEquatable.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;

namespace Tests.Records
{
    [TestClass]
    public partial class NoAttributes
    {
        [Equatable]
        public abstract partial record A
        {
        }

        [Equatable]
        public abstract partial record B : A
        {
        }

        [Equatable]
        public partial record C : B
        {
            public int Value { get; set; }
        }

        [Equatable]
        public partial record TempData
        {
            public int Age { get; set; }

            public string? Name { get; set; }
        }

        [Equatable]
        public partial record TempData2
        {
            public int Age { get; set; }

            public string? Name { get; set; }
        }

        [TestClass]
        public class EqualTest : EqualityTestWithOperatorBase
        {
            public override bool MustBeEqual => true;

            public override object Data1() => new TempData { Name = "Juan", Age = 21 };

            public override object Data2() => new TempData { Name = "Juan", Age = 21 };

            public override bool EqualsOperator(object value1, object value2) => (TempData)value1 == (TempData)value2;

            public override bool NotEqualsOperator(object value1, object value2) => (TempData)value1 != (TempData)value2;
        }

        [TestClass]
        public class NotEqualTest : EqualityTestWithOperatorBase
        {
            public override bool MustBeEqual => false;

            public override object Data1() => new TempData { Name = "Juan", Age = 21 };

            public override object Data2() => new TempData { Name = "Juan", Age = 22 };

            public override bool EqualsOperator(object value1, object value2) => (TempData)value1 == (TempData)value2;

            public override bool NotEqualsOperator(object value1, object value2) => (TempData)value1 != (TempData)value2;
        }

        [TestClass]
        public class NotEqualTestDifferentType : EqualityTestBase
        {
            public override bool MustBeEqual => false;

            public override object Data1() => new TempData { Name = "Juan", Age = 21 };

            public override object Data2() => new TempData2 { Name = "Juan", Age = 21 };
        }

        [TestClass]
        public class NotEqualTestSameReference : EqualityTestBase
        {
            public override bool MustBeEqual => true;

            public static object Main => new TempData { Name = "Juan", Age = 21 };

            public override object Data1() => Main;

            public override object Data2() => Main;
        }
    }
}