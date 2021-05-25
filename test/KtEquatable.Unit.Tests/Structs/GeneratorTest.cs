using KtEquatable.Unit.Tests.Assertions;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.Assertions.TestDataSourceAttributes.BasicDataSourceAttribute;
using static KtEquatable.Unit.Tests.Assertions.AssertionHelpers;
using KtEquatable.Unit.Tests.Assertions.TestDataSourceAttributes;

namespace KtEquatable.Unit.Tests.Structs
{
    [TestClass]
    public class GeneratorTest
    {
        private const string objName = "A";
        private const string propName = "P1";
        private const bool skipEqOp = false;
        private const bool forIgnoreAtt = false;

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.NonClass, true, objName,propName, typeof(SourceStruct))]
        public void NoneClassFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.NonClass, false, objName,propName, typeof(SourceStruct))]
        public void NoneClassCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Class, true, objName,propName, typeof(SourceStruct))]
        public void ClassFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Class, false, objName,propName, typeof(SourceStruct))]
        public void ClassCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Dictionary, true, objName,propName, typeof(SourceStruct))]
        public void DictionaryFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Dictionary, false, objName,propName, typeof(SourceStruct))]
        public void DictionaryCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Enumerable, true, objName, propName, typeof(SourceStruct))]
        public void EnumerableFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Enumerable, false, objName, propName, typeof(SourceStruct))]
        public void EnumerableCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }
    }
}