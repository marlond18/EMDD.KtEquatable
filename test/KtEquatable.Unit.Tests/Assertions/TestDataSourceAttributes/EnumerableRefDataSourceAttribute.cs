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
    public class EnumerableRefDataSourceAttribute : BaseTestDataSourceAttribute
    {
        public EnumerableOrderType OrderType { get; }
        protected readonly bool isClass;

        public EnumerableRefDataSourceAttribute(EnumerableOrderType orderType, bool friendlyName, string objName, string propName, bool isClass, Type type) : base(friendlyName, objName, propName, type)
        {
            OrderType = orderType;
            this.isClass = isClass;
        }

        protected override (Type type, string comparer, TypeInfo<IPropertySymbol> diag) InitialSourceClassInfo(Type type, ComparerSyntax comparerSyntax)
        {
            return (type, comparerSyntax(type), isClass ? null : ReferenceEqualityMustBeClass);
        }

        protected override (ComparerSyntax comparerSyntax, string[] attributes) GetComparerDetail()
        {
            return OrderType switch
            {
                EnumerableOrderType.Ordered => (OrderedComparerSyntax(true, isClass ? ReferenceComparerSyntax : Basic),
                new[] { EnumerableOrderedAttr, ReferenceAttr }),
                EnumerableOrderType.Set => (SetComparerSyntax(true, isClass ? ReferenceComparerSyntax : Basic),
                new[] { EnumerableSetAttr, ReferenceAttr }),
                _ => (UnorderedComparerSyntax(true, isClass ? ReferenceComparerSyntax : Basic),
                new[] { EnumerableUnorderedAttr, ReferenceAttr }),
            };
        }

        protected override IEnumerable<Type> GetTypes()
        {
            if (isClass)
            {
                return BasicClassTypes().Select(ListOfEnumerables).SelectMany(f => f);
            }
            else
            {
                return ListOfAllNonClass().Select(ListOfEnumerables).SelectMany(f => f);
            }
        }
    }
}
