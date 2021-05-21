using EMDD.KtEquatable.Core.Attributes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Classes
{
    [TestClass]
    public partial class DoubleEnumerableTests
    {
        [Equatable]
        public partial class A
        {
            [EnumerableEquality(EnumerableOrderType.Unordered)]
            [FloatingPointEquality(2)]
            public List<double>? D { get; set; }
        }

        [TestClass]
        public class NotInOrderPass : EqualityTestWithOperatorBase
        {
            public override bool MustBeEqual => true;

            public override object Data1() => new A { D = new List<double> { 1, 2.003, 3, 4 } };
            public override object Data2() => new A { D = new List<double> { 1, 3, 2.004, 4 } };

            public override bool EqualsOperator(object value1, object value2) => (A)value1 == (A)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (A)value1 != (A)value2;
        }

        [TestClass]
        public class NotInOrderDecimalFail : EqualityTestWithOperatorBase
        {
            public override bool MustBeEqual => false;

            public override object Data1() => new A { D = new List<double> { 1, 2.03, 3, 4 } };
            public override object Data2() => new A { D = new List<double> { 1, 3, 2.04, 4 } };

            public override bool EqualsOperator(object value1, object value2) => (A)value1 == (A)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (A)value1 != (A)value2;
        }

        [Equatable]
        public partial class B
        {
            [EnumerableEquality(EnumerableOrderType.Ordered)]
            [FloatingPointEquality(2)]
            public List<double>? D { get; set; }
        }

        [TestClass]
        public class MustBeInOrderFail : EqualityTestWithOperatorBase
        {
            public override bool MustBeEqual => false;

            public override object Data1() => new B { D = new List<double> { 1, 2.003, 3, 4 } };
            public override object Data2() => new B { D = new List<double> { 1, 3, 2.004, 4 } };

            public override bool EqualsOperator(object value1, object value2) => (B)value1 == (B)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (B)value1 != (B)value2;
        }

        [TestClass]
        public class MustBeInOrderPass : EqualityTestWithOperatorBase
        {
            public override bool MustBeEqual => true;

            public override object Data1() => new B { D = new List<double> { 1, 3, 2.003, 4 } };
            public override object Data2() => new B { D = new List<double> { 1, 3, 2.004, 4 } };

            public override bool EqualsOperator(object value1, object value2) => (B)value1 == (B)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (B)value1 != (B)value2;
        }

        [TestClass]
        public class MustBeInOrderCountFail : EqualityTestWithOperatorBase
        {
            public override bool MustBeEqual => false;

            public override object Data1() => new B { D = new List<double> { 1, 3, 2.003, 4, 5 } };
            public override object Data2() => new B { D = new List<double> { 1, 3, 2.004, 4 } };

            public override bool EqualsOperator(object value1, object value2) => (B)value1 == (B)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (B)value1 != (B)value2;
        }
    }
}
