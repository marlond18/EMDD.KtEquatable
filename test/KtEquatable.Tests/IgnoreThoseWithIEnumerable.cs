
using EMDD.KtEquatable.Core.Attributes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;

namespace KtEquatable.Tests.Classes
{
    [TestClass]
    public partial class IgnoreThoseWithIEnumerable
    {
        [Equatable]
        public partial class EmployeeInfo : IEquatable<EmployeeInfo>
        {
            public string? Name { get; set; }

            public int Id { get; set; }

            public bool Equals(EmployeeInfo? other)
            {
                return false;
            }
        }

        [TestClass]
        public class FailTestEquals : EqualityTestWithOperatorBase
        {
            public override bool MustBeEqual => false;
            public override object Data1() => new EmployeeInfo { Name = "Bob", Id = 2 };
            public override object Data2() => new EmployeeInfo { Name = "Bob", Id = 2 };
            public override bool EqualsOperator(object value1, object value2) => (EmployeeInfo)value1 == (EmployeeInfo)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (EmployeeInfo)value1 != (EmployeeInfo)value2;
        }
    }
}