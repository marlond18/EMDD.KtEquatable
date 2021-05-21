
using EMDD.KtEquatable.Core.Attributes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;

namespace Tests.Classes
{
#nullable enable
    [TestClass]
    public partial class MixedTests
    {
        [Equatable]
        public partial class EmployeeInfo
        {
            public string? Name { get; set; }

            [IgnoreEquality]
            public int Id { get; set; }

            [FloatingPointEquality(4)]
            public double Salary { get; set; }

            [EnumerableEquality(EnumerableOrderType.Unordered)]
            public Dictionary<string, int>? BankAccountDetails { get; set; }

            [EnumerableEquality(EnumerableOrderType.Ordered)]
            public List<DateTime>? TimeIn { get; set; }

            [ReferenceEquality]
            public EmployeeInfo? Superior { get; set; }

            [ReferenceEquality]
            public string? SocialSecurity { get; set; }
        }

        private static readonly EmployeeInfo Boss1 = new() { Name = "Bob", Id = 1 };
        private static readonly EmployeeInfo Boss2 = new() { Name = "Bob", Id = 2 };

        [TestClass]
        public class TestIgnoreEquals : EqualityTestWithOperatorBase
        {
            public override bool MustBeEqual => true;
            public override object Data1() => Boss1;
            public override object Data2() => Boss2;
            public override bool EqualsOperator(object value1, object value2) => (EmployeeInfo)value1 == (EmployeeInfo)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (EmployeeInfo)value1 != (EmployeeInfo)value2;
        }

        private static readonly EmployeeInfo Employee1 = new()
        {
            Name = "Chipotle",
            Id = 3,
            Salary = 10000.0003,
            BankAccountDetails = new Dictionary<string, int> { { "Wells", 123 }, { "JP", 234 }, { "BoA", 345 } },
            Superior = Boss1,
            TimeIn = new List<DateTime> { new DateTime(2012, 3, 4), new DateTime(2012, 3, 5), new DateTime(2012, 3, 6) },
            SocialSecurity = "AAA"
        };

        private const string SS = "BBB";

        private static readonly EmployeeInfo Employee2 = new()
        {
            Name = "Chipotle",
            Id = 3,
            Salary = 10000.0003,
            BankAccountDetails = new Dictionary<string, int> { { "Wells", 123 }, { "JP", 234 }, { "BoA", 345 } },
            Superior = Boss2,
            TimeIn = new List<DateTime> { new DateTime(2012, 3, 4), new DateTime(2012, 3, 5), new DateTime(2012, 3, 6) },
            SocialSecurity = SS
        };

        private static readonly EmployeeInfo Employee3 = new()
        {
            Name = "Chipotle",
            Id = 3,
            Salary = 10000.0004,
            BankAccountDetails = new Dictionary<string, int> { { "Wells", 123 }, { "JP", 234 }, { "BoA", 345 } },
            Superior = Boss2,
            TimeIn = new List<DateTime> { new DateTime(2012, 3, 4), new DateTime(2012, 3, 5), new DateTime(2012, 3, 6) },
            SocialSecurity = SS
        };

        [TestClass]
        public class ReferencePropAttributeNotEquals : EqualityTestWithOperatorBase
        {
            public override bool MustBeEqual => false;
            public override object Data1() => Employee1;
            public override object Data2() => Employee2;
            public override bool EqualsOperator(object value1, object value2) => (EmployeeInfo)value1 == (EmployeeInfo)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (EmployeeInfo)value1 != (EmployeeInfo)value2;
        }

        [TestClass]
        public class ReferenceEqual : EqualityTestWithOperatorBase
        {
            public override bool MustBeEqual => true;
            public override object Data1() => Employee1;
            public override object Data2() => Employee1;
            public override bool EqualsOperator(object value1, object value2) => (EmployeeInfo)value1 == (EmployeeInfo)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (EmployeeInfo)value1 != (EmployeeInfo)value2;
        }

        [TestClass]
        public class FloatingPointNotEquals : EqualityTestWithOperatorBase
        {
            public override bool MustBeEqual => false;
            public override object Data1() => Employee2;
            public override object Data2() => Employee3;
            public override bool EqualsOperator(object value1, object value2) => (EmployeeInfo)value1 == (EmployeeInfo)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (EmployeeInfo)value1 != (EmployeeInfo)value2;
        }

        private static readonly EmployeeInfo Employee4 = new()
        {
            Name = "Karen",
            Id = 3,
            Salary = 10000.00004,
            BankAccountDetails = new Dictionary<string, int> { { "Wells", 123 }, { "JP", 234 }, { "BoA", 345 } },
            Superior = Boss2,
            TimeIn = new List<DateTime> { new DateTime(2012, 3, 4), new DateTime(2012, 3, 5), new DateTime(2012, 3, 6) },
            SocialSecurity = SS
        };

        private static readonly EmployeeInfo Employee5 = new()
        {
            Name = "Karen",
            Id = 3,
            Salary = 10000.00005,
            BankAccountDetails = new Dictionary<string, int> { { "Wells", 123 }, { "JP", 234 }, { "BoA", 345 } },
            Superior = Boss2,
            TimeIn = new List<DateTime> { new DateTime(2012, 3, 4), new DateTime(2012, 3, 5), new DateTime(2012, 3, 6) },
            SocialSecurity = SS
        };

        [TestClass]
        public class FloatingPointEquals : EqualityTestWithOperatorBase
        {
            public override bool MustBeEqual => true;
            public override object Data1() => Employee4;
            public override object Data2() => Employee5;
            public override bool EqualsOperator(object value1, object value2) => (EmployeeInfo)value1 == (EmployeeInfo)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (EmployeeInfo)value1 != (EmployeeInfo)value2;
        }

        private static readonly EmployeeInfo Employee6 = new()
        {
            Name = "Karen",
            Id = 3,
            Salary = 10000.00004,
            BankAccountDetails = new Dictionary<string, int> { { "JP", 234 }, { "BoA", 345 }, { "Wells", 123 } },
            Superior = Boss2,
            TimeIn = new List<DateTime> { new DateTime(2012, 3, 4), new DateTime(2012, 3, 5), new DateTime(2012, 3, 6) },
            SocialSecurity = SS
        };

        private static readonly EmployeeInfo Employee7 = new()
        {
            Name = "Karen",
            Id = 3,
            Salary = 10000.00005,
            BankAccountDetails = new Dictionary<string, int> { { "Wells", 123 }, { "JP", 234 }, { "BoA", 345 } },
            Superior = Boss2,
            TimeIn = new List<DateTime> { new DateTime(2012, 3, 4), new DateTime(2012, 3, 5), new DateTime(2012, 3, 6) },
            SocialSecurity = SS
        };

        [TestClass]
        public class UnorderedEquals : EqualityTestWithOperatorBase
        {
            public override bool MustBeEqual => true;
            public override object Data1() => Employee6;
            public override object Data2() => Employee7;
            public override bool EqualsOperator(object value1, object value2) => (EmployeeInfo)value1 == (EmployeeInfo)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (EmployeeInfo)value1 != (EmployeeInfo)value2;
        }

        private static readonly EmployeeInfo Employee8 = new()
        {
            Name = "Karen",
            Id = 3,
            Salary = 10000.00004,
            BankAccountDetails = new Dictionary<string, int> { { "JP", 234 }, { "BoA", 345 }, { "Wells", 123 } },
            Superior = Boss2,
            TimeIn = new List<DateTime> { new DateTime(2012, 3, 5), new DateTime(2012, 3, 4), new DateTime(2012, 3, 6) },
            SocialSecurity = SS
        };

        private static readonly EmployeeInfo Employee9 = new()
        {
            Name = "Karen",
            Id = 3,
            Salary = 10000.00005,
            BankAccountDetails = new Dictionary<string, int> { { "Wells", 123 }, { "JP", 234 }, { "BoA", 345 } },
            Superior = Boss2,
            TimeIn = new List<DateTime> { new DateTime(2012, 3, 4), new DateTime(2012, 3, 5), new DateTime(2012, 3, 6) },
            SocialSecurity = SS
        };

        [TestClass]
        public class OrderedNotEquals : EqualityTestWithOperatorBase
        {
            public override bool MustBeEqual => false;
            public override object Data1() => Employee8;
            public override object Data2() => Employee9;
            public override bool EqualsOperator(object value1, object value2) => (EmployeeInfo)value1 == (EmployeeInfo)value2;
            public override bool NotEqualsOperator(object value1, object value2) => (EmployeeInfo)value1 != (EmployeeInfo)value2;
        }
    }
#nullable restore
}