using KtEquatable.Unit.Tests.Records.TestDataSourceAttributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.Records.TestDataSourceAttributes.BasicDataSourceAttribute;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;

namespace KtEquatable.Unit.Tests.Records
{
    [TestClass]
    public class GeneratorTest
    {
        private const string className = "A";
        private const string propName = "P1";

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.NonClass, true, className,propName)]
        public void NoneClassFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.NonClass, false, className,propName)]
        public void NoneClassCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Class, true, className,propName)]
        public void ClassFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Class, false, className,propName)]
        public void ClassCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Dictionary, true, className,propName)]
        public void DictionaryFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Dictionary, false, className,propName)]
        public void DictionaryCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Enumerable, true, className, propName)]
        public void EnumerableFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Enumerable, false, className, propName)]
        public void EnumerableCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }
    }
}