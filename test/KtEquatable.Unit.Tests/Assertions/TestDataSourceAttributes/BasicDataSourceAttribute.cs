using KtEquatable.Unit.Tests.Assertions;

using Microsoft.CodeAnalysis;

using System;
using System.Collections.Generic;
using System.Linq;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;
using static KtEquatable.Unit.Tests.TestSyntaxHelper;

namespace KtEquatable.Unit.Tests.Assertions.TestDataSourceAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class BasicDataSourceAttribute : BaseTestDataSourceAttribute
    {
        public enum DataTypeGroup
        {
            Class = 0,
            NonClass = 1,
            Enumerable = 2,
            Dictionary = 3
        }

        private readonly DataTypeGroup dataTypeGroup;

        public BasicDataSourceAttribute(DataTypeGroup dataTypeGroup, bool friendlyName, string className, string propName, Type type) : base(friendlyName, className, propName, type)
        {
            this.dataTypeGroup = dataTypeGroup;
        }

        protected override (Type type, string comparer, TypeInfo<IPropertySymbol> diag) InitialSourceClassInfo(Type type, ComparerSyntax comparerSyntax)
        {
            return (type, comparerSyntax(type), null);
        }

        protected override (ComparerSyntax comparerSyntax, string[] attributes) GetComparerDetail()
        {
            return (Basic, null);
        }

        protected override IEnumerable<Type> GetTypes()
        {
            return dataTypeGroup switch
            {
                DataTypeGroup.Class => BasicClassTypes(),
                DataTypeGroup.NonClass => ListOfAllNonClass(),
                DataTypeGroup.Dictionary => BasicClassTypes().SelectMany(f => ListOfAllNonClass().SelectMany(ff => ListOfDictionaries(f, ff))).Concat(ListOfClassDict),
                _ => ListOfAllNonClass().Concat(BasicClassTypes()).Select(ListOfEnumerables).SelectMany(f => f)
            };
        }

        private static IEnumerable<Type> RandomTypes => new[] {
            typeof(int),
            typeof(string),
            typeof(ClassTypeForTest),
            typeof(EnumTypeForTest),
            typeof(StructTypeForTest) };

        private static IEnumerable<Type> ListOfClassDict => RandomTypes.Tabulate(RandomTypes).Select(t => ListOfDictionaries(t.a, t.b)).SelectMany(f => f);
    }
}
