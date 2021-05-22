using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using EMDD.KtEquatable.Core.Attributes;

namespace KtEquatable.Tests.Classes
{
    [TestClass]
    public partial class DictionaryEquality
    {
        [Equatable]
        public partial class Data
        {
            [EnumerableEquality(EnumerableOrderType.Unordered)]
            public Dictionary<string, int>? Properties { get; set; }
        }

        [TestClass]
        public class EqualTest : EqualityTestWithOperatorBase
        {
            public override bool Expected => true;

            public override object Factory1() => new Data
            {
                Properties = Enumerable.Range(1, 1000).ToDictionary(x => x.ToString(), x => x)
            };

            public override object Factory2() => Factory1();

            public override bool EqualsOperator(object value1, object value2) => (Data)value1 == (Data)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (Data)value1 != (Data)value2;
        }

        [TestClass]
        public class NotEqualTest : EqualityTestWithOperatorBase
        {
            public override bool Expected => false;

            public override object Factory1() => new Data
            {
                Properties = Enumerable.Range(1, 1000).ToDictionary(x => x.ToString(), x => x)
            };

            public override object Factory2() => new Data
            {
                Properties = Enumerable.Range(2, 999).ToDictionary(x => x.ToString(), x => x)
            };

            public override bool EqualsOperator(object value1, object value2) => (Data)value1 == (Data)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (Data)value1 != (Data)value2;
        }
    }
}