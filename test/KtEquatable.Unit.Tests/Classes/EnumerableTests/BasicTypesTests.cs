using EMDD.KtEquatable.Core.Attributes;

using KtEquatable.Unit.Tests.Assertions;
using KtEquatable.Unit.Tests.Assertions.TestDataSourceAttributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;
using static KtEquatable.Unit.Tests.Assertions.AssertionHelpers;
using System;

namespace KtEquatable.Unit.Tests.Classes.EnumerableTests
{
    [TestClass]
    public class BasicTypesTests
    {
        private const string objName = "A";
        private const string propName = "P1";
        private const bool skipEqOp = false;
        private const bool forIgnoreAtt = false;

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceClass), EnumerableOrderType.Ordered, true, objName, propName, typeof(int), typeof(int?))]
        public void OrderedIntPropFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceClass), EnumerableOrderType.Ordered, false, objName, propName, typeof(int), typeof(int?))]
        public void OrderedIntPropCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceClass), EnumerableOrderType.Unordered, true, objName, propName, typeof(int), typeof(int?))]
        public void UnorderedIntPropFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceClass), EnumerableOrderType.Unordered, false, objName, propName, typeof(int), typeof(int?))]
        public void UnorderedIntPropCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceClass), EnumerableOrderType.Set, true, objName, propName, typeof(int), typeof(int?))]
        public void SetIntPropFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceClass), EnumerableOrderType.Set, false, objName, propName, typeof(int), typeof(int?))]
        public void SetIntPropCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceClass), EnumerableOrderType.Ordered, true, objName, propName, typeof(string))]
        public void OrderedStringPropFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceClass), EnumerableOrderType.Ordered, false, objName, propName, typeof(string))]
        public void OrderedStringPropCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceClass), EnumerableOrderType.Unordered, true, objName, propName, typeof(string))]
        public void UnorderedStringPropFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceClass), EnumerableOrderType.Unordered, false, objName, propName, typeof(string))]
        public void UnorderedStringPropCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceClass), EnumerableOrderType.Set, true, objName, propName, typeof(string))]
        public void SetStringPropFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [TestMethod]
        [EnumerableBasicTypeDataSource(typeof(SourceClass), EnumerableOrderType.Set, false, objName, propName, typeof(string))]
        public void SetStringPropCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }
    }
}