# Diagnostic Reports (added on 3.0.0)
## Compilation Error:
### KTEQG1
- Static classes can't be marked as Equatable
### KtEQG6
- Error when the Precision of `FloatingPointEqualityAttribute` is less than 0.
## Compilation Warning:
### KTEQG2
- classes should not be marked with Equatable and and manually derive from IEquatable<T> at the same time.
### KTEQG3
- warning occurs when a class is derived from an abstract class not implementing IEquatable<T>
### KtEQG4
- Warning occurs when a type is not supported for source generation
### KtEQG7
- occurs when the attribute does not match the property type. example: a string property is marked with FloatingPointEqualityAttributed
### KtEQG8
- Dictionary cannot be marked as EnumerableOrderType.Ordered 
### KtEQG9
- Dictionary cannot be marked as EnumerableOrderType.Set
### KtEQG10
- putting IgnoreEqualityAttribute together with other equality attributes is redundant. The other attributes will be ignored
### KtEQG11
- Can't mark indexers for equality comparison. Property will be ignored
### KtEQG12
- Property cannot be used for equality comparison when it is Writeonly
### KtEQG13
- ReferenceEqualityAttribute must be used on class type properties only
