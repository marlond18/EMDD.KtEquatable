using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMDD.KtEquatable.Core.Attributes;

namespace KtEquatable.Tests.Classes
{
    [TestClass]
    public partial class IgnoreEquality
    {
        [Equatable]
        public partial class Data
        {
            public Data(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public string Name { get; }

            [IgnoreEquality]
            public int Age { get; }
        }

        [TestClass]
        public class EqualTest : EqualityTestWithOperatorBase
        {
            public override bool Expected => true;
            public override object Factory1() => new Data("Juan", 35);
            public override object Factory2() => new Data("Juan", 85);
            public override bool EqualsOperator(object value1, object value2) => (Data)value1 == (Data)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (Data)value1 != (Data)value2;
        }

        [TestClass]
        public class NotEqualTest : EqualityTestWithOperatorBase
        {
            public override bool Expected => false;
            public override object Factory1() => new Data("Juan", 35);
            public override object Factory2() => new Data("Pedro", 35);
            public override bool EqualsOperator(object value1, object value2) => (Data)value1 == (Data)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (Data)value1 != (Data)value2;
        }
    }
}