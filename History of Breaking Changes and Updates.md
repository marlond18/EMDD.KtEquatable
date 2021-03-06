# Breaking Changes and Updates
## (3.1.0 to 3.2.0)
- In the previous version, the attributes and equality comparer must be exposed, which means that the output build must be a library; was removed ```<IncludeBuildOutput>false</IncludeBuildOutput>```. In the new update, the attributes and equalitycomparers are also included in the generated code making it possible to add ```<IncludeBuildOutput>false</IncludeBuildOutput>``` in the package settings, making the package purely as an analyzer.
## (3.0.0 to 3.1.0)
- added support for struct types
## (2.0.2 to 3.0.0)
- ditched EMDD.KtEquatable.Core, it's  not needed any longer.
    * The `<IncludeBuildOutput>false</IncludeBuildOutput>` has to be removed in order for the custom attributes to be visible for use, this way the project is treated both as an analyzer and a common library. The only problem is that if a project using this source generator is referenced by another project, this source generator will also be visible on the referencing project.
- Added [Diagnostic Reports](https://github.com/marlond18/EMDD.KtEquatable/blob/main/Diagnostics.md) (Compilation Error Reports)
- Changes on the Attribute usage particularly `FloatingPointEqualityAttribute`
    - the use of the precision parameter `FloatingPointEqualityAttribute`
    - Enumerable attributes can be combined with `ReferenceEqualityAttribute` and `FloatingPointEqualityAttribute` to produce combined effect
    - `UnorderedEquality`, `OrderedEquality`, and `SetEquality` was replaced with `EnumerableEquality` with parameters
- Improvement on the indentions of the autogenerated codes
- `DoubleEnumerableEqualityAttribute`,  has been removed
## (2.0.1 to 2.0.2)
- Added [```[DoubleEnumerableEqualityAttribute]```](https://github.com/marlond18/EMDD.KtEquatable/blob/main/src/EMDD.KtEquatable.Core/Attributes/DoubleEnumerableEqualityAttribute.cs)
## (1.0.0 to 2.0.1)
- A major breaking change was implemented from 1.0.0 to 2.0.1. The original namespace used to access the Attributes was changed from  ```EMDD.KtSourceGen.KtEquatable.Core``` to ```EMDD.KtEquatable.Core.Attributes```
- Implementation improvement for the checking of base class was also introduced. If the base class that the class marked with ```[Equatable]``` Attribute was derived from implements ```IEnumerable<T>``` or is marked with ```[Equatable]``` Attribute itself, the implementation of the Equals checking and GetHashCode will pick-up the Equals and GetHashCode implementation of the base class, but for base classes that does not derive ```IEquatable<T>``` or has no ```[Equatable]```, the Equals and GetHashCode implementation bypass the base class, instead, the Equals and GetHashCode  will use property of the base class + it's own properties in the computation.
-  The Attributes and custom EqualityComparers are now placed under ```EMDD.KtEquatable.Core``` package, instead of being autogenerated. This will eliminate conflicting codes if two projects uses this package. 
