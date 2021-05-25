using EMDD.KtEquatable.Core.Attributes;

using Microsoft.CodeAnalysis;

using System;
using System.Collections.Generic;
using System.Linq;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.Assertions.AssertionHelpers;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;
using static KtEquatable.Unit.Tests.TestSyntaxHelper;

namespace KtEquatable.Unit.Tests.Assertions.TestDataSourceAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class DictionaryRefDataSourceAttribute : BaseTestDataSourceAttribute
    {
        public EnumerableOrderType OrderType { get; }
        protected readonly bool isClass;

        public DictionaryRefDataSourceAttribute(EnumerableOrderType orderType, bool friendlyName, string objectName, string propName, bool isClass, Type type) : base(friendlyName, objectName, propName, type)
        {
            OrderType = orderType;
            this.isClass = isClass;
        }

        protected override (ComparerSyntax comparerSyntax, string[] attributes) GetComparerDetail()
        {
            return OrderType switch
            {
                EnumerableOrderType.Unordered => (DictionaryComparerSyntax(true, isClass ? ReferenceComparerSyntax : Basic),
                new[] { EnumerableUnorderedAttr, ReferenceAttr }),
                EnumerableOrderType.Set => (Basic,
                new[] { EnumerableSetAttr, ReferenceAttr }),
                _ => (Basic,
                new[] { EnumerableOrderedAttr, ReferenceAttr }),
            };
        }

        protected override IEnumerable<Type> GetTypes()
        {
            if (isClass)
            {
                return (new[] { typeof(string), typeof(ClassTypeForTest), typeof(EnumTypeForTest), typeof(StructTypeForTest) })
                    .Tabulate(BasicClassTypes())
                    .Select(t => ListOfDictionaries(t.a, t.b)).SelectMany(f => f);
            }
            else
            {
                return ListOfAllNonClass().SelectMany(f => ListOfDictionaries(typeof(string), f)).Concat(
                    ListOfAllNonClass().SelectMany(f => ListOfDictionaries(typeof(ClassTypeForTest), f)));
            }
        }

        protected override (Type type, string comparer, TypeInfo<IPropertySymbol> diag) InitialSourceClassInfo(Type type, ComparerSyntax comparerSyntax)
        {
            return (type, comparerSyntax(type), OrderType switch
            {
                EnumerableOrderType.Unordered => isClass ? null : ReferenceEqualityMustBeClass,
                EnumerableOrderType.Set => DictionaryCantBeSetType,
                _ => DictionaryCantBeOrderedType
            });
        }
    }
}
