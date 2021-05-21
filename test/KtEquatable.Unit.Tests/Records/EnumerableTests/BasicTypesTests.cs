using EMDD.KtEquatable.Core.Attributes;

using KtEquatable.Unit.Tests.Records.TestDataSourceAttributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;

namespace KtEquatable.Unit.Tests.Records.EnumerableTests
{
    [TestClass]
    public class BasicTypesTests
    {
        private const string className = "A";
        private const string propName = "P1";

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Ordered, true, className, propName, typeof(int), typeof(int?))]
        public void OrderedIntPropFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Ordered,false, className, propName, typeof(int), typeof(int?))]
        public void OrderedIntPropCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Unordered, true, className, propName, typeof(int), typeof(int?))]
        public void UnorderedIntPropFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Unordered, false, className, propName, typeof(int), typeof(int?))]
        public void UnorderedIntPropCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Set, true, className, propName, typeof(int), typeof(int?))]
        public void SetIntPropFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Set, false, className, propName, typeof(int), typeof(int?))]
        public void SetIntPropCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Ordered,true, className, propName, typeof(string))]
        public void OrderedStringPropFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Ordered,false, className, propName, typeof(string))]
        public void OrderedStringPropCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Unordered, true, className, propName, typeof(string))]
        public void UnorderedStringPropFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Unordered, false, className, propName, typeof(string))]
        public void UnorderedStringPropCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Set, true, className, propName, typeof(string))]
        public void SetStringPropFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Set, false, className, propName, typeof(string))]
        public void SetStringPropCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }
    }
}
