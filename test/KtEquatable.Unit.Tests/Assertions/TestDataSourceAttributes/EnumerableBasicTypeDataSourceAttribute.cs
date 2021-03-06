using EMDD.KtEquatable.Core.Attributes;

using Microsoft.CodeAnalysis;

using System;
using System.Collections.Generic;
using System.Linq;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;
using static KtEquatable.Unit.Tests.Assertions.AssertionHelpers;
using static KtEquatable.Unit.Tests.TestSyntaxHelper;
using KtEquatable.Unit.Tests.Assertions;

namespace KtEquatable.Unit.Tests.Assertions.TestDataSourceAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class EnumerableBasicTypeDataSourceAttribute : BaseTestDataSourceAttribute
    {
        private readonly Type[] types;
        private readonly EnumerableOrderType orderType;

        public EnumerableBasicTypeDataSourceAttribute(Type type, EnumerableOrderType orderType, bool friendlyName, string objName, string propName, params Type[] types) : base(friendlyName, objName, propName, type)
        {
            this.types = types;
            this.orderType = orderType;
        }

        protected override (Type type, string comparer, TypeInfo<IPropertySymbol> diag) InitialSourceClassInfo(Type type, ComparerSyntax comparerSyntax)
        {
            return (type, comparerSyntax(type), null);
        }

        protected override (ComparerSyntax comparerSyntax, string[] attributes) GetComparerDetail()
        {
            return orderType switch
            {
                EnumerableOrderType.Ordered => (OrderedComparerSyntax(true, Basic), new[] { EnumerableOrderedAttr }),
                EnumerableOrderType.Unordered => (UnorderedComparerSyntax(true, Basic), new[] { EnumerableUnorderedAttr }),
                _ => (SetComparerSyntax(true, Basic), new[] { EnumerableSetAttr }),
            };
        }

        protected override IEnumerable<Type> GetTypes()
        {
            return types.SelectMany(ListOfEnumerables);
        }
    }
}
