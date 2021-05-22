using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMDD.KtEquatable.Core.Attributes;

namespace KtEquatable.Tests.Classes
{
    [TestClass]
    public partial class FloatingPointEquality
    {
        [Equatable]
        public partial class Data
        {
            public Data(double value)
            {
                Value = value;
            }

            [FloatingPointEquality(11)]
            public double Value { get; }
        }

        [TestClass]
        public class EqualTest : EqualityTestWithOperatorBase
        {
            public override bool Expected => true;
            public override object Factory1() => new Data(0.1000000000011);
            public override object Factory2() => new Data(0.1000000000021);
            public override bool EqualsOperator(object value1, object value2) => (Data)value1 == (Data)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (Data)value1 != (Data)value2;
        }

        [TestClass]
        public class NotEqualTest : EqualityTestWithOperatorBase
        {
            public override bool Expected => false;
            public override object Factory1() => new Data(0.100000000011);
            public override object Factory2() => new Data(0.100000000021);
            public override bool EqualsOperator(object value1, object value2) => (Data)value1 == (Data)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (Data)value1 != (Data)value2;
        }
    }
}