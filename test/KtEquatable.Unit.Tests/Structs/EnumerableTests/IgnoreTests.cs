using EMDD.KtEquatable.Core.Attributes;

using KtEquatable.Unit.Tests.Assertions;
using KtEquatable.Unit.Tests.Assertions.TestDataSourceAttributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;
using static KtEquatable.Unit.Tests.Assertions.AssertionHelpers;

namespace KtEquatable.Unit.Tests.Structs.EnumerableTests
{
    [TestClass]
    public class IgnoreTests
    {
        private const string objName = "A";
        private const string propName = "P1";
        private const bool skipEqOp = false;
        private const bool forIgnoreAtt = true;

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, true, objName, propName, false, typeof(SourceStruct))]
        public void IgnoreOrderedNonClassFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, true, objName, propName, true, typeof(SourceStruct))]
        public void IgnoreOrderedClassFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, true, objName, propName, false, typeof(SourceStruct))]
        public void IgnoreUnorderedNonClassFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, true, objName, propName, true, typeof(SourceStruct))]
        public void IgnoreUnorderedClassFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, true, objName, propName, false, typeof(SourceStruct))]
        public void IgnoreSetNonClassFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, true, objName, propName, true, typeof(SourceStruct))]
        public void IgnoreSetClassFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, false, objName, propName, false, typeof(SourceStruct))]
        public void IgnoreOrderedNonClassCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Ordered, false, objName, propName, true, typeof(SourceStruct))]
        public void IgnoreOrderedClassCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, false, objName, propName, false, typeof(SourceStruct))]
        public void IgnoreUnorderedNonClassCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Unordered, false, objName, propName, true, typeof(SourceStruct))]
        public void IgnoreUnorderedClassCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, false, objName, propName, false, typeof(SourceStruct))]
        public void IgnoreSetNonClassCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableIgnoredDataSource(EnumerableOrderType.Set, false, objName, propName, true, typeof(SourceStruct))]
        public void IgnoreSetClassCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }
    }
}
