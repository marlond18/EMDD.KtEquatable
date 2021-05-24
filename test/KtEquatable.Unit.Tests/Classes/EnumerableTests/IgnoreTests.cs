using EMDD.KtEquatable.Core.Attributes;

using KtEquatable.Unit.Tests.Assertions;
using KtEquatable.Unit.Tests.Assertions.TestDataSourceAttributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;
using static KtEquatable.Unit.Tests.Assertions.AssertionHelpers;

namespace KtEquatable.Unit.Tests.Classes.EnumerableTests
{
    [TestClass]
    public class IgnoreTests
    {
        private const string className = "A";
        private const string propName = "P1";
        private const bool skipEqOp = false;
        private const bool forIgnoreAtt = true;

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, true, className, propName, false, typeof(SourceClass))]
        public void IgnoreOrderedNonClassFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, true, className, propName, true, typeof(SourceClass))]
        public void IgnoreOrderedClassFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, true, className, propName, false, typeof(SourceClass))]
        public void IgnoreUnorderedNonClassFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, true, className, propName, true, typeof(SourceClass))]
        public void IgnoreUnorderedClassFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, true, className, propName, false, typeof(SourceClass))]
        public void IgnoreSetNonClassFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, true, className, propName, true, typeof(SourceClass))]
        public void IgnoreSetClassFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, false, className, propName, false, typeof(SourceClass))]
        public void IgnoreOrderedNonClassCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, false, className, propName, true, typeof(SourceClass))]
        public void IgnoreOrderedClassCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, false, className, propName, false, typeof(SourceClass))]
        public void IgnoreUnorderedNonClassCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, false, className, propName, true, typeof(SourceClass))]
        public void IgnoreUnorderedClassCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, false, className, propName, false, typeof(SourceClass))]
        public void IgnoreSetNonClassCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, false, className, propName, true, typeof(SourceClass))]
        public void IgnoreSetClassCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }
    }
}
