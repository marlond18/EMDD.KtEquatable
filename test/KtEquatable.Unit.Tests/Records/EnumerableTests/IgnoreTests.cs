using EMDD.KtEquatable.Core.Attributes;

using KtEquatable.Unit.Tests.Assertions;
using KtEquatable.Unit.Tests.Assertions.TestDataSourceAttributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.Assertions.AssertionHelpers;

namespace KtEquatable.Unit.Tests.Records.EnumerableTests
{
    [TestClass]
    public class IgnoreTests
    {
        private const string className = "A";
        private const string propName = "P1";
        private const bool skipEqOp = true;
        private const bool forIgnoreAtt = true;

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, true, className, propName, false, typeof(SourceRecord))]
        public void IgnoreOrderedNonClassFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, true, className, propName, true, typeof(SourceRecord))]
        public void IgnoreOrderedClassFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, true, className, propName, false, typeof(SourceRecord))]
        public void IgnoreUnorderedNonClassFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, true, className, propName, true, typeof(SourceRecord))]
        public void IgnoreUnorderedClassFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, true, className, propName, false, typeof(SourceRecord))]
        public void IgnoreSetNonClassFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, true, className, propName, true, typeof(SourceRecord))]
        public void IgnoreSetClassFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, false, className, propName, false, typeof(SourceRecord))]
        public void IgnoreOrderedNonClassCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, false, className, propName, true, typeof(SourceRecord))]
        public void IgnoreOrderedClassCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, false, className, propName, false, typeof(SourceRecord))]
        public void IgnoreUnorderedNonClassCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, false, className, propName, true, typeof(SourceRecord))]
        public void IgnoreUnorderedClassCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, false, className, propName, false, typeof(SourceRecord))]
        public void IgnoreSetNonClassCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, false, className, propName, true, typeof(SourceRecord))]
        public void IgnoreSetClassCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }
    }
}