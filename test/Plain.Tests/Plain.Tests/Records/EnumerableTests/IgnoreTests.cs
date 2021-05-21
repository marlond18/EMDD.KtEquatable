using EMDD.KtEquatable.Core.Attributes;

using KtEquatable.Unit.Tests.Records.TestDataSourceAttributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;

namespace KtEquatable.Unit.Tests.Records.EnumerableTests
{
    [TestClass]
    public class IgnoreTests
    {
        private const string className = "A";
        private const string propName = "P1";

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, true, className, propName, false)]
        public void IgnoreOrderedNonClassFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, true, className, propName, true)]
        public void IgnoreOrderedClassFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, true, className, propName, false)]
        public void IgnoreUnorderedNonClassFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, true, className, propName, true)]
        public void IgnoreUnorderedClassFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, true, className, propName, false)]
        public void IgnoreSetNonClassFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, true, className, propName, true)]
        public void IgnoreSetClassFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, false, className, propName, false)]
        public void IgnoreOrderedNonClassCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, false, className, propName, true)]
        public void IgnoreOrderedClassCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, false, className, propName, false)]
        public void IgnoreUnorderedNonClassCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, false, className, propName, true)]
        public void IgnoreUnorderedClassCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, false, className, propName, false)]
        public void IgnoreSetNonClassCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, false, className, propName, true)]
        public void IgnoreSetClassCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }
    }
}
