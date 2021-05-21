using EMDD.KtEquatable.Core.Attributes;

using Microsoft.CodeAnalysis;

using System;
using System.Collections.Generic;
using System.Linq;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;
using static KtEquatable.Unit.Tests.TestGeneratorHelper.SourceRecord;
using static KtEquatable.Unit.Tests.TestSyntaxHelper;

namespace KtEquatable.Unit.Tests.Records.TestDataSourceAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class FloatDataSourceAttribute : BaseTestDataSourceAttribute
    {
        private readonly int precision;
        private readonly bool correctData;

        public FloatDataSourceAttribute(int precision, bool friendlyName, string className, string propName, bool correctData) : base(friendlyName, className, propName)
        {
            this.precision = precision;
            this.correctData = correctData;
        }

        protected override (Type type, string comparer, TypeInfo<IPropertySymbol> diag) InitialSourceClassInfo(Type type, ComparerSyntax comparerSyntax)
        {
            return (type, comparerSyntax(type), correctData ? precision < 0 ? FloatingPointPrecisionLessZero : null : WrongTypeApplication);
        }

        protected override (ComparerSyntax comparerSyntax, string[] attributes) GetComparerDetail()
        {
            if (!correctData)
            {
                return (Basic, new[] { FloatingPointAttr(precision) });
            }
            if (precision < 0)
            {
                return (Basic, new[] { FloatingPointAttr(precision) });
            }
            return (FloatComparerSyntax(precision), new[] { FloatingPointAttr(precision) });
        }

        protected override IEnumerable<Type> GetTypes()
        {
            if (correctData)
            {
                return ListOfFloats();
            }
            return ListOfNonFloat();
        }
    }
}
