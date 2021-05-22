using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public abstract class EqualityTestBase
    {
        public abstract bool MustBeEqual { get; }
        public abstract object Data1();
        public abstract object Data2();

        [TestMethod("DefaultEquality")]
        public void EqualsTest1()
        {
            var data1 = Data1();
            var data2 = Data2();
            if (MustBeEqual)
            {
                Assert.AreEqual(data1, data2, $"data1:{data1} and data2:{data2} should be equal");
            }
            else
            {
                Assert.AreNotEqual(data1, data2, $"data1:{data1} and data2:{data2} should be not equal");
            }
        }

        [TestMethod("Equal<T>(T other)")]
        public void EqualsTest3()
        {
            var data1 = Data1();
            var data2 = Data2();
            if (MustBeEqual)
            {
                Assert.IsTrue(data1.Equals(data2), $"data1:{data1} and data2:{data2} should be equal");
            }
            else
            {
                Assert.IsFalse(data1.Equals(data2), $"data1:{data1} and data2:{data2} should be not equal");
            }
        }
    }

    [TestClass]
    public abstract class EqualityTestWithOperatorBase : EqualityTestBase
    {
        public abstract bool EqualsOperator(object value1, object value2);
        public abstract bool NotEqualsOperator(object value1, object value2);

        [TestMethod("Using Equality operator")]
        public void EqualsTest2()
        {
            var data1 = Data1();
            var data2 = Data2();
            if (MustBeEqual)
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