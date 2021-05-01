using EMDD.KtSourceGen.KtEquatable.Syntax;
using EMDD.KtSourceGen.KtEquatable.Syntax.Property;

using Microsoft.CodeAnalysis;

using System.Linq;

using static EMDD.KtSourceGen.KtEquatable.Core.CoreHelpers;
namespace EMDD.KtSourceGen.KtEquatable.Core
{
    public sealed class AttributeTypeSymbolCollection
    {
        public INamedTypeSymbol Equatable { get; }
        public INamedTypeSymbol OrderedEquality { get; }
        public INamedTypeSymbol IgnoreEquality { get; }
        public INamedTypeSymbol UnorderedEquality { get; }
        public INamedTypeSymbol ReferenceEquality { get; }
        public INamedTypeSymbol SetEquality { get; }
        public INamedTypeSymbol FloatingPointEquality { get; }

        public static AttributeTypeSymbolCollection Create(GeneratorExecutionContext context)
        {
            return new AttributeTypeSymbolCollection(context);
        }

        private AttributeTypeSymbolCollection(GeneratorExecutionContext context)
        {
            Equatable = context.Compilation.GetTypeByMetadataName($"{NameSpace}.Core.{EquatableAttributeName}")!;
            OrderedEquality = context.Compilation.GetTypeByMetadataName($"{NameSpace}.Core.{OrderedEqualityAttributeName}")!;
            IgnoreEquality = context.Compilation.GetTypeByMetadataName($"{NameSpace}.Core.{IgnoreEqualityAttributeName}")!;
            UnorderedEquality = context.Compilation.GetTypeByMetadataName($"{NameSpace}.Core.{UnorderedEqualityAttributeName}")!;
            ReferenceEquality = context.Compilation.GetTypeByMetadataName($"{NameSpace}.Core.{ReferenceEqualityAttributeName}")!;
            SetEquality = context.Compilation.GetTypeByMetadataName($"{NameSpace}.Core.{SetEqualityAttributeName}")!;
            FloatingPointEquality = context.Compilation.GetTypeByMetadataName($"{NameSpace}.Core.{FloatingPointEqualityAttributeName}")!;
        }

        public PropertyEqualityBase ToPropertyEquality(IPropertySymbol property, bool ignoreIfContract)
        {
            var propertyName = property.ToFullyQualifiedFormat();
            if (ignoreIfContract && propertyName == "EqualityContract") return null;
            if (property.HasAttribute(Equatable)) return null;
            if (property.HasAttribute(IgnoreEquality)) return new PropertyIgnoreEquality();
            var typeName = property.Type.ToNullableFullyQualifiedFormat();
            if (property.HasAttribute(UnorderedEquality))
            {
                var types = property.GetIDictionaryTypeArguments();
                if (types != null) return new PropertyDictionaryEquality { Name = propertyName, Type = string.Join(", ", types.Value) };

                types = property.GetIEnumerableTypeArguments()!;
                return new PropertyUnorderedCollectionEquality { Name = propertyName, Type = string.Join(", ", types.Value) };
            }
            else if (property.HasAttribute(OrderedEquality))
            {
                var types = property.GetIEnumerableTypeArguments()!;
                return new PropertyOrderedCollectionEquality { Name = propertyName, Type = string.Join(", ", types.Value) };
            }
            else if (property.HasAttribute(ReferenceEquality))
            {
                return new PropertyReferenceEquality { Name = propertyName, Type = typeName };
            }
            else if (property.HasAttribute(SetEquality))
            {
                var types = property.GetIEnumerableTypeArguments()!;
                return new PropertySetEquality { Name = propertyName, Type = string.Join(", ", types.Value) };
            }
            else if (property.HasAttribute(FloatingPointEquality) && typeName == "global::System.Double")
            {
                var at = property.GetAttribute(FloatingPointEquality);
                if (at is not null)
                {
                    var precisionStr = at.NamedArguments.SingleOrDefault(kvp => kvp.Key == "Precision").Value;
                    if (!precisionStr.IsNull && int.TryParse(precisionStr.Value.ToString(), out int val))
                    {
                        return new PropertyFloatingPointEquality { Name = propertyName, Type = typeName, Precision = val };
                    }
                }
                return new PropertyDefaultEquality { Name = propertyName, Type = typeName };
            }
            else
            {
                return new PropertyDefaultEquality { Name = propertyName, Type = typeName };
            }
        }

        private static string EquatableAttributeName => "EquatableAttribute";
        private static string OrderedEqualityAttributeName => "OrderedEqualityAttribute";
        private static string IgnoreEqualityAttributeName => "IgnoreEqualityAttribute";
        private static string UnorderedEqualityAttributeName => "UnorderedEqualityAttribute";
        private static string ReferenceEqualityAttributeName => "ReferenceEqualityAttribute";
        private static string SetEqualityAttributeName => "SetEqualityAttribute";
        private static string FloatingPointEqualityAttributeName => "FloatingPointEqualityAttribute";

        public static string AttributeCode => $@"
using System;

namespace {NameSpace}.Core
{{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class {EquatableAttributeName} : Attribute
    {{
    }}

    [AttributeUsage(AttributeTargets.Property)]
    public class {OrderedEqualityAttributeName} : Attribute
    {{
    }}

    [AttributeUsage(AttributeTargets.Property)]
    public class {IgnoreEqualityAttributeName} : Attribute
    {{
    }}

    [AttributeUsage(AttributeTargets.Property)]
    public class {UnorderedEqualityAttributeName} : Attribute
    {{
    }}

    [AttributeUsage(AttributeTargets.Property)]
    public class {ReferenceEqualityAttributeName} : Attribute
    {{
    }}

    [AttributeUsage(AttributeTargets.Property)]
    public class {SetEqualityAttributeName} : Attribute
    {{
    }}

    [AttributeUsage(AttributeTargets.Property)]
    public class {FloatingPointEqualityAttributeName} : Attribute
    {{
        public int Precision {{ get; set;}} = 10;
    }}
}}";
    }
}
