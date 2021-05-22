using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMDD.KtEquatable.Core.Attributes;

namespace KtEquatable.Tests.Classes
{
    [TestClass]
    public partial class NullableEquality : EqualityTestWithOperatorBase
    {
        public override bool Expected => true;

        [Equatable]
        public partial class Data
        {
            [EnumerableEquality(EnumerableOrderType.Ordered)]
            public string[]? Addresses { get; set; }
        }

        public override object Factory1() => new Data();
        public override object Factory2() => Factory1();
        public override bool EqualsOperator(object value1, object value2) => (Data)value1 == (Data)value2;
        public override bool NotEqualsOperator(object value1, object value2) => (Data)value1 != (Data)value2;
    }
}