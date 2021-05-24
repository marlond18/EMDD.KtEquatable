using KtEquatable.Unit.Tests.Assertions;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.Assertions.AssertionHelpers;
using static KtEquatable.Unit.Tests.Assertions.TestDataSourceAttributes.BasicDataSourceAttribute;
using KtEquatable.Unit.Tests.Assertions.TestDataSourceAttributes;

namespace KtEquatable.Unit.Tests.Records
{
    [TestClass]
    public class GeneratorTest
    {
        private const string className = "A";
        private const string propName = "P1";
        private const bool skipEqOp = true;
        private const bool forIgnoreAtt = false;

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.NonClass, true, className,propName, typeof(SourceRecord))]
        public void NoneClassFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.NonClass, false, className,propName, typeof(SourceRecord))]
        public void NoneClassCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Class, true, className,propName, typeof(SourceRecord))]
        public void ClassFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Class, false, className,propName, typeof(SourceRecord))]
        public void ClassCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Dictionary, true, className,propName, typeof(SourceRecord))]
        public void DictionaryFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Dictionary, false, className,propName, typeof(SourceRecord))]
        public void DictionaryCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Enumerable, true, className, propName, typeof(SourceRecord))]
        public void EnumerableFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Enumerable, false, className, propName, typeof(SourceRecord))]
        public void EnumerableCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }
    }
}