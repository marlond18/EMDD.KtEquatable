using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMDD.KtEquatable.Core.Attributes;

namespace KtEquatable.Tests.Classes
{
    [TestClass]
    public partial class GenericParameterEquality
    {
        [Equatable]
        public partial class Data<TName, TAge>
        {
            public Data(TName name, TAge age)
            {
                Name = name;
                Age = age;
            }

            public TName Name { get; }
            public TAge Age { get; }
        }

        [TestClass]
        public class EqualTest : EqualityTestWithOperatorBase
        {
            public override bool Expected => true;
            public override object Factory1() => new Data<string, int>("Dave", 35);
            public override object Factory2() => Factory1();

            public override bool EqualsOperator(object value1, object value2) =>
                (Data<string, int>)value1 == (Data<string, int>)value2;

            public override bool NotEqualsOperator(object value1, object value2) =>
                (Data<string, int>)value1 != (Data<string, int>)value2;
        }

        [TestClass]
        public class NotEqualTest : EqualityTestWithOperatorBase
        {
            public override bool Expected => false;
            public override object Factory1() => new Data<string, int>("Dave", 35);
            public override object Factory2() => new Data<string, int>("Dave", 37);

            public override bool EqualsOperator(object value1, object value2) =>
                (Data<string, int>)value1 == (Data<string, int>)value2;

            public override bool NotEqualsOperator(object value1, object value2) =>
                (Data<string, int>)value1 != (Data<string, int>)value2;
        }
    }
}