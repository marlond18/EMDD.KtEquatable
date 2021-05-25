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
    public class BasicTypesTests
    {
        private const string objName = "A";
        private const string propName = "P1";
        private const bool skipEqOp = true;
        private const bool forIgnoreAtt = false;

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceRecord), EnumerableOrderType.Ordered, true, objName, propName, typeof(int), typeof(int?))]
        public void OrderedIntPropFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceRecord), EnumerableOrderType.Ordered,false, objName, propName, typeof(int), typeof(int?))]
        public void OrderedIntPropCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceRecord), EnumerableOrderType.Unordered, true, objName, propName, typeof(int), typeof(int?))]
        public void UnorderedIntPropFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceRecord), EnumerableOrderType.Unordered, false, objName, propName, typeof(int), typeof(int?))]
        public void UnorderedIntPropCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceRecord), EnumerableOrderType.Set, true, objName, propName, typeof(int), typeof(int?))]
        public void SetIntPropFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceRecord), EnumerableOrderType.Set, false, objName, propName, typeof(int), typeof(int?))]
        public void SetIntPropCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceRecord), EnumerableOrderType.Ordered,true, objName, propName, typeof(string))]
        public void OrderedStringPropFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceRecord), EnumerableOrderType.Ordered,false, objName, propName, typeof(string))]
        public void OrderedStringPropCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceRecord), EnumerableOrderType.Unordered, true, objName, propName, typeof(string))]
        public void UnorderedStringPropFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceRecord), EnumerableOrderType.Unordered, false, objName, propName, typeof(string))]
        public void UnorderedStringPropCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceRecord), EnumerableOrderType.Set, true, objName, propName, typeof(string))]
        public void SetStringPropFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceRecord), EnumerableOrderType.Set, false, objName, propName, typeof(string))]
        public void SetStringPropCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }
    }
}
