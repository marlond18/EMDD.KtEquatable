using KtEquatable.Unit.Tests.Assertions;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.Assertions.TestDataSourceAttributes.BasicDataSourceAttribute;
using static KtEquatable.Unit.Tests.Assertions.AssertionHelpers;
using KtEquatable.Unit.Tests.Assertions.TestDataSourceAttributes;

namespace KtEquatable.Unit.Tests.Classes
{
    [TestClass]
    public class GeneratorTest
    {
        private const string className = "A";
        private const string propName = "P1";
        private const bool skipEqOp = false;
        private const bool forIgnoreAtt = false;

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.NonClass, true, className,propName, typeof(SourceClass))]
        public void NoneClassFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.NonClass, false, className,propName, typeof(SourceClass))]
        public void NoneClassCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Class, true, className,propName, typeof(SourceClass))]
        public void ClassFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Class, false, className,propName, typeof(SourceClass))]
        public void ClassCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Dictionary, true, className,propName, typeof(SourceClass))]
        public void DictionaryFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Dictionary, false, className,propName, typeof(SourceClass))]
        public void DictionaryCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Enumerable, true, className, propName, typeof(SourceClass))]
        public void EnumerableFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [BasicDataSource(DataTypeGroup.Enumerable, false, className, propName, typeof(SourceClass))]
        public void EnumerableCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }
    }
}