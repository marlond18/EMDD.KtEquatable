using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KtEquatable.Tests
{
    [TestClass]
    public abstract class EqualityTestBase
    {
        public abstract bool Expected { get; }
        public abstract object Factory1();
        public abstract object Factory2();

        [TestMethod("Equal objects using the default object equality method")]
        public void EqualsTest1()
        {
            var data1 = Factory1();
            var data2 = Factory2();
            if (Expected)
            {
                Assert.AreEqual(data1, data2, $"data1:{data1} and data2:{data2} should be equal");
            }
            else
            {
                Assert.AreNotEqual(data1, data2, $"data1:{data1} and data2:{data2} should be not equal");
            }
        }
    }

    [TestClass]
    public abstract class EqualityTestWithOperatorBase : EqualityTestBase
    {
        public abstract bool EqualsOperator(object value1, object value2);
        public abstract bool NotEqualsOperator(object value1, object value2);

        [TestMethod("Equal objects using the equality operator")]
        public void EqualsTest2()
        {
            var data1 = Factory1();
            var data2 = Factory2();
            if (Expected)
            {
                Assert.IsTrue(EqualsOperator(data1, data2), $"data1:{data1} and data2:{data2} should be equal");
            }
            else
            {
                Assert.IsTrue(NotEqualsOperator(data1, data2), $"data1:{data1} and data2:{data2} should be not equal");
            }
        }
    }
}