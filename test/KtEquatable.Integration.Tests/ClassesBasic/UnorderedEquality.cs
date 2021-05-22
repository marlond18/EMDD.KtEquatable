using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMDD.KtEquatable.Core.Attributes;

namespace KtEquatable.Tests.Classes
{
    [TestClass]
    public partial class UnorderedEquality
    {
        [EMDD.KtEquatable.Core.Attributes.Equatable]
        public partial class Data
        {
            [EnumerableEquality(EnumerableOrderType.Unordered)]
            public List<int>? Properties { get; set; }
        }

        [TestClass]
        public class EqualsTests : EqualityTestWithOperatorBase
        {
            public override bool Expected => true;
            public override object Factory1()
            {
                var randomSort = new Random();

                // This should generate objects with the same contents, but different orders, thus proving
                // that dictionary equality is being used instead of the normal sequence equality.
                return new Data
                {
                    Properties = Enumerable
                        .Range(1, 1000)
                        .OrderBy(_ => randomSort.NextDouble())
                        .ToList()
                };
            }
            public override object Factory2() => Factory1();

            public override bool EqualsOperator(object value1, object value2) => (Data)value1 == (Data)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (Data)value1 != (Data)value2;
        }

        [TestClass]
        public class NotEqualsTest : EqualityTestWithOperatorBase
        {
            public override bool Expected => false;

            public override object Factory1() => new Data
            {
                Properties = Enumerable.Range(1, 1000).ToList()
            };

            public override object Factory2() => new Data
            {
                Properties = Enumerable.Range(1, 1001).ToList()
            };

            public override bool EqualsOperator(object value1, object value2) => (Data)value1 == (Data)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (Data)value1 != (Data)value2;
        }
    }
}