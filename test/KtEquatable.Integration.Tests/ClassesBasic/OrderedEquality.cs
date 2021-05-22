using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMDD.KtEquatable.Core.Attributes;

namespace KtEquatable.Tests.Classes
{
    [TestClass]
    public partial class OrderedEquality
    {
        [EMDD.KtEquatable.Core.Attributes.Equatable]
        public partial class Data
        {
            public Data(string[] addresses)
            {
                Addresses = addresses;
            }

            [EnumerableEquality(EnumerableOrderType.Ordered)]
            public string[] Addresses { get; }
        }

        [TestClass]
        public class EqualsTest : EqualityTestWithOperatorBase
        {
            public override bool Expected => true;
            public override object Factory1() => new Data(new[] { "10 Downing St" });
            public override object Factory2() => Factory1();
            public override bool EqualsOperator(object value1, object value2) => (Data)value1 == (Data)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (Data)value1 != (Data)value2;
        }

        [TestClass]
        public class NotEqualsTest : EqualityTestWithOperatorBase
        {
            public override bool Expected => false;
            public override object Factory1() => new Data(new[] { "10 Downing St" });
            public override object Factory2() => new Data(new[] { "Bricklane" });
            public override bool EqualsOperator(object value1, object value2) => (Data)value1 == (Data)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (Data)value1 != (Data)value2;
        }
    }
}