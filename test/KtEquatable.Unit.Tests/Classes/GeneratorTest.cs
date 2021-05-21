using KtEquatable.Unit.Tests.Classes.TestDataSourceAttributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.Classes.TestDataSourceAttributes.BasicDataSourceAttribute;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;

namespace KtEquatable.Unit.Tests.Classes
{
    [TestClass]
    public class GeneratorTest
    {
        private const string className = "A";
        private const string propName = "P1";

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.NonClass, true, className,propName)]
        public void NoneClassFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.NonClass, false, className,propName)]
        public void NoneClassCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Class, true, className,propName)]
        public void ClassFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Class, false, className,propName)]
        public void ClassCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Dictionary, true, className,propName)]
        public void DictionaryFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Dictionary, false, className,propName)]
        public void DictionaryCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Enumerable, true, className, propName)]
        public void EnumerableFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Enumerable, false, className, propName)]
        public void EnumerableCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }
    }
}