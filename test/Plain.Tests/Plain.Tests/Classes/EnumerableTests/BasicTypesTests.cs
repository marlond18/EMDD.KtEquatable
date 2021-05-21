using EMDD.KtEquatable.Core.Attributes;

using KtEquatable.Unit.Tests.Classes.TestDataSourceAttributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;

namespace KtEquatable.Unit.Tests.Classes.EnumerableTests
{
    [TestClass]
    public class BasicTypesTests
    {
        private const string className = "A";
        private const string propName = "P1";

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Ordered, true, className, propName, typeof(int), typeof(int?))]
        public void OrderedIntPropFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Ordered,false, className, propName, typeof(int), typeof(int?))]
        public void OrderedIntPropCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Unordered, true, className, propName, typeof(int), typeof(int?))]
        public void UnorderedIntPropFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Unordered, false, className, propName, typeof(int), typeof(int?))]
        public void UnorderedIntPropCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Set, true, className, propName, typeof(int), typeof(int?))]
        public void SetIntPropFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Set, false, className, propName, typeof(int), typeof(int?))]
        public void SetIntPropCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Ordered,true, className, propName, typeof(string))]
        public void OrderedStringPropFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Ordered,false, className, propName, typeof(string))]
        public void OrderedStringPropCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Unordered, true, className, propName, typeof(string))]
        public void UnorderedStringPropFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Unordered, false, className, propName, typeof(string))]
        public void UnorderedStringPropCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Set, true, className, propName, typeof(string))]
        public void SetStringPropFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(EnumerableOrderType.Set, false, className, propName, typeof(string))]
        public void SetStringPropCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }
    }
}
