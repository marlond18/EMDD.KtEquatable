<img align="left" src="src/EMDD.KtEquatable/Images/emd2.png" width="120" height="50">

&nbsp;

&nbsp; [![Nuget](https://img.shields.io/nuget/v/EMDD.KtEquatable)](https://www.nuget.org/packages/EMDD.KtEquatable/)[![Nuget](https://img.shields.io/nuget/dt/EMDD.KtEquatable)](https://www.nuget.org/stats/packages/EMDD.KtEquatable?groupby=Version&groupby=ClientName&groupby=ClientVersion)[![GitHub Workflow Status](https://img.shields.io/github/workflow/status/marlond18/EMDD.KtEquatable/RunTests)](https://github.com/marlond18/EMDD.KtEquatable/actions/workflows/runTest.yml)
&nbsp; 
----------------
# EMDD.KtEquatable
use of C# 9.0 Source Generator to AutoGenerate IEquatable&lt;T&gt; using attributes.

## Requirements

[Visual Studio 16.8](https://visualstudio.microsoft.com/vs) or greater

[.Net 5.0.102 sdk](https://dotnet.microsoft.com/download/dotnet/5.0) or greater

## Nuget Package Usage

https://www.nuget.org/packages/EMDD.KtEquatable/

`<PackageReference Include="EMDD.KtEquatable" Version="*.*.*" />`

If you intend to use this generator on projects that are intended as libraries to be consumed by other projects make sure to set the `<PrivateAssets>all</PrivateAssets>`. example syntax on your csproj file:
```
<PackageReference Include="EMDD.KtEquatable" Version="3.1.0">
  <PrivateAssets>all</PrivateAssets>
</PackageReference>
```

## Breaking Changes and Updates 
### (3.1.0 to 3.2.0)
- In the previous version, the attributes and equality comparer must be exposed, which means that the output build must be a library; had to remove ```<IncludeBuildOutput>false</IncludeBuildOutput>```. In the new update, the attributes and equalitycomparers are also included in the generated code making it possible to add ```<IncludeBuildOutput>false</IncludeBuildOutput>``` in the package settings, making the package purely as an analyzer.

see [History of Breaking Changes and Updates](https://github.com/marlond18/EMDD.KtEquatable/blob/main/History%20of%20Breaking%20Changes%20and%20Updates.md)

## Usage
The source generator can be used by marking the target class/record/struct with ```[Equatable]``` Attribute. The property members can also be marked with specific attributes to dictate the equality comparison method to be used.
The sample below shows an `EmployeeInfo` class marked with the specific Attributes.
```c#
using EMDD.KtEquatable.Core.Attributes;
 
[Equatable]
partial class EmployeeInfo
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
        Console.WriteLine(employee2 == employee3);
    }
}
```
*note: the class marked with [Equatable] including its parent/containing classes must be marked as partial*

## Supported Attributes
### Class/Record/Struct Declaration Attributes
#### Equatable
The code generator will only recognize ```class```, ```record``` or ```struct``` marked with  ```[Equatable]```.

### Property Attributes
#### Default (No Attribute)
A property that is not marked by any Attributes mentioned below will produce a generated code that uses ```EqualityComparer<T>.Default``` when checking Equality and calculating Hashcode.

#### IgnoreEquality
Properties marked with ```[IgnoreEquality]``` will not be included in the equality checking and Hashcode calculation
```c#
[IgnoreEquality] 
public string Name { get; set; }
```

#### FloatingPointEquality
```c#
[FloatingPointEquality(10)]
public double Salary { get; set; } // Must be double
```
A property marked with ```[FloatingPointEquality]``` will be used in the comparison of equality such that the difference between the compared value should not be less than the precision. the property will be compared using the build-in EqualityComparer:
```c#
FloatingPointEqualityComparer
```

#### ReferenceEquality
A property marked with ```[ReferenceEquality]``` will use Reference equality checking only
```c#
[ReferenceEquality]
public Employee Superior { get; set; }
```

#### EnumerableEquality
Comparison of Collections/IEnumerables with specific requirements such as when the order is not or is required or if the collection can have repeated elements.
```c#
[Equatable]
partial class Book 
{
    [EnumerableEquality(EnumerableOrderType.Ordered)]
    public DateTime[] Borrower { get; set; } 

    [EnumerableEquality(EnumerableOrderType.Unordered)]
    public string[] BookTitle { get; set; } 

    [EnumerableEquality(EnumerableOrderType.Set)]
    public HashSet<string> Borrowers { get; set; }
}
```
`ReferenceEquality` and `FloatingPointEquality` can also be mixed with `EnumerableEquality`. Say if you want to compare an List of unordered double property with 3 decimal point precisions:
```c#
[Equatable]
partial class Mechanic
{
    [EnumerableEquality(EnumerableOrderType.Ordered)]
    [FLoatingPointEquality(3)]
    public System.List<double> Payments { get; set; } 
}
```
The `Payments` property will be compared using `new UnorderedEqualityComparer(new FloatingPointEqualityComparer(3))`

## Diagnostic Reports
Compile-time Diagnostic reports were added at `3.0.0`.
see [Diagnostic Lists](https://github.com/marlond18/EMDD.KtEquatable/blob/main/Diagnostics.md)
