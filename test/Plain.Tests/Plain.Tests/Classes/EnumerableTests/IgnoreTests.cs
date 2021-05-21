using EMDD.KtEquatable.Core.Attributes;

using KtEquatable.Unit.Tests.Classes.TestDataSourceAttributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;

namespace KtEquatable.Unit.Tests.Classes.EnumerableTests
{
    [TestClass]
    public class IgnoreTests
    {
        private const string className = "A";
        private const string propName = "P1";

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, true, className, propName, false)]
        public void IgnoreOrderedNonClassFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, true, className, propName, true)]
        public void IgnoreOrderedClassFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, true, className, propName, false)]
        public void IgnoreUnorderedNonClassFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, true, className, propName, true)]
        public void IgnoreUnorderedClassFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, true, className, propName, false)]
        public void IgnoreSetNonClassFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, true, className, propName, true)]
        public void IgnoreSetClassFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, false, className, propName, false)]
        public void IgnoreOrderedNonClassCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, false, className, propName, true)]
        public void IgnoreOrderedClassCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, false, className, propName, false)]
        public void IgnoreUnorderedNonClassCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, false, className, propName, true)]
        public void IgnoreUnorderedClassCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, false, className, propName, false)]
        public void IgnoreSetNonClassCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, false, className, propName, true)]
        public void IgnoreSetClassCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName, true);
        }
    }
}
