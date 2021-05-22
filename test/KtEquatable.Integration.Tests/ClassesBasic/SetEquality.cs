using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMDD.KtEquatable.Core.Attributes;

namespace KtEquatable.Tests.Classes
{
    [TestClass]
    public partial class SetEquality
    {
        [EMDD.KtEquatable.Core.Attributes.Equatable]
        public partial class Data
        {
            [EnumerableEquality(EnumerableOrderType.Set)]
            public List<int>? Properties { get; set; }
        }

        [TestClass]
        public class EqualsTests : EqualityTestWithOperatorBase
        {
            public override bool Expected => true;
            public override object Factory1()
            {
                return new Data
                {
                    Properties = new List<int> { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 }
                };
            }

            public override object Factory2()
            {
                return new Data
                {
                    Properties = new List<int> { 1, 5, 2, 4, 3 }
                };
            }

            public override bool EqualsOperator(object value1, object value2) => (Data)value1 == (Data)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (Data)value1 != (Data)value2;
        }

        [TestClass]
        public class NotEqualsTest : EqualityTestWithOperatorBase
        {
            public override bool Expected => false;

            public override object Factory1() => new Data
            {
                Properties = new List<int> { 1, 2, 3, 4, 5 }
            };

            public override object Factory2() => new Data
            {
                Properties = new List<int> { 1, 2, 3, 4 }
            };

            public override bool EqualsOperator(object value1, object value2) => (Data)value1 == (Data)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (Data)value1 != (Data)value2;

            [TestMethod]
            public void HashCode()
            {
                var value1 = Factory1();
                var value2 = Factory2();

                Assert.IsTrue(value1.GetHashCode() == value2.GetHashCode());
            }
        }
    }
}
#nullable disable