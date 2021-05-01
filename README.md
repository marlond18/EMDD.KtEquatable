![Nuget](https://img.shields.io/nuget/v/EMDD.KtSourceGen.KtEquatable?style=flat-square)
# EMDD.KtEquatable
use of C# 9.0 Source Generator to AutoGenerate IEquatable&lt;T&gt; using attributes.

----------------

## Usage
The source generator can be used by marking the target class with ```[Equatable]``` Attribute. The properties can also be marked with specific attributes specify the equality comparison method to be used.
The sample below shows an EmployeeInfo class marked with the specific Attributes.
```c#
using EMDD.KtSourceGen.KtEquatable.Core;

[Equatable]
partial class EmployeeInfo
{
    public string? Name { get; set; }
    
    [IgnoreEquality]
    public int Id { get; set; }

    [FloatingPointEquality(Precision = 4)]
    public double Salary { get; set; }

    [UnorderedEquality]
    public Dictionary<string, int>? BankAccountDetails { get; set; }

    [OrderedEquality]
    public List<DateTime>? TimeIn { get; set; }

    [ReferenceEquality]
    public EmployeeInfo? Superior { get; set; }

    [ReferenceEquality]
    public string? SocialSecurity { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        const string SS = "BBB";
        
        EmployeeInfo boss1 = new EmployeeInfo() { Name = "Bob", Id = 1 };
        EmployeeInfo boss2 = new EmployeeInfo() { Name = "Bob", Id = 2 };
        EmployeeInfo employee1 = new EmployeeInfo() {
            Name = "Chipotle",
            Id = 3,
            Salary = 10000.0003,
            BankAccountDetails = new Dictionary<string, int> { { "Wells", 123 }, { "JP", 234 }, { "BoA", 345 } },
            Superior = boss1,
            TimeIn= new List<DateTime> { new DateTime (2012,3,4), new DateTime(2012, 3, 5), new DateTime(2012, 3, 6) },
            SocialSecurity="AAA"
        };
        EmployeeInfo employee2 = new EmployeeInfo() {
            Name = "Chipotle",
            Id = 3,
            Salary = 10000.0003,
            BankAccountDetails = new Dictionary<string, int> { { "Wells", 123 }, { "JP", 234 }, { "BoA", 345 } },
            Superior = boss2,
            TimeIn= new List<DateTime> { new DateTime (2012,3,4), new DateTime(2012, 3, 5), new DateTime(2012, 3, 6)},
            SocialSecurity= SS
        };
        EmployeeInfo employee3 = new EmployeeInfo() {
            Name = "Chipotle",
            Id = 3,
            Salary = 10000.0004,
            BankAccountDetails = new Dictionary<string, int> { { "Wells", 123 }, { "JP", 234 }, { "BoA", 345 } },
            Superior = boss2,
            TimeIn= new List<DateTime> { new DateTime (2012,3,4), new DateTime(2012, 3, 5), new DateTime(2012, 3, 6) },
            SocialSecurity = SS
        };
        Console.WriteLine(employee1 != employee2);
        Console.WriteLine(employee2 != employee3);
    }
}
```
## Supported Attributes

### Equatable
The code generator will only recognize ```class``` or```record```marked with  ```[Equatable]```.

### Default
A property that is not marked by any Attributes mentioned below will produce a generated code that uses ```EqualityComparer<T>.Default``` when checking Equality and calculating Hashcode.

### IgnoreEquality
Properties marked with ```[IgnoreEquality]``` will not be included in the equality checking and Hashcode calculation
```c#
[IgnoreEquality] 
public string Name { get; set; }
```

### FloatingPointEquality
```c#
[FloatingPointEquality(Precision = 10)]
public double Salary { get; set; } // Must be double
```
A property marked with ```[FloatingPointEquality]``` will be used in the comparison of equality such that the difference between the compared value should not be less than the precision. the property will be equal if:
```c#
System.Math.Abs(_value1.Salary - _value2.Salary) < System.Math.Pow(10,-Precision)
```
The hashcode is also computed by rounding off the value of the property
```c#
System.Math.Round(Salary * System.Math.Pow(10,Precision), 0).GetHashCode();
```

### OrderedEquality, UnorderedEquality, and SetEquality
Comparison of Collections/IEnumerables with specific requirements such as when the order is not or is required or if the collection can have repeated elements.
```c#
[Equatable]
partial class Book 
{
    [OrderedEquality] 
    public DateTime[] Borrower { get; set; } 

    [UnorderedEquality] 
    public string[] BookTitle { get; set; } 

    [SetEquality] 
    public HashSet<string> Borrowers { get; set; }
}
```

### ReferenceEquality
A property marked with ```[ReferenceEquality]``` will use Reference equality checking only
```c#
[ReferenceEquality]
public Employee Superior { get; set; }
```
