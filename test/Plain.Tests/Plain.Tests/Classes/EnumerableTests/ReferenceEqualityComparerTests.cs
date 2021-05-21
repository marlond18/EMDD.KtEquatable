
using EMDD.KtEquatable.Core.Attributes;

using KtEquatable.Unit.Tests.Classes.TestDataSourceAttributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;

namespace KtEquatable.Unit.Tests.Classes.EnumerableTests
{
    [TestClass]
    public class ReferenceEqualityComparerTests
    {
        private const string className = "Data";
        private const string propName = "P1";

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set, true, className, propName,false)]
        public void SetNonClassTypeFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Ordered, true, className, propName, false)]
        public void OrderedNonClassTypeFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, true, className, propName, false)]
        public void UnorderedNonClassTypeFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set,false, className, propName, false)]
        public void SetNonClassTypeCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Ordered, false, className, propName, false)]
        public void OrderedNonClassTypeCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, false, className, propName, false)]
        public void UnorderedNonClassTypeCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set, true, className, propName, true)]
        public void SetClassTypeFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Ordered, true, className, propName, true)]
        public void OrderedClassTypeFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, true, className, propName, true)]
        public void UnorderedClassTypeFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set, false, className, propName, true)]
        public void SetClassTypeCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Ordered, false, className, propName, true)]
        public void OrderedClassTypeCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, false, className, propName, true)]
        public void UnorderedClassTypeCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource( EnumerableOrderType.Set,true, className,propName,false )]
        public void SetDictionaryNonClassFriendlyNameTypeTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, true, className, propName, false)]
        public void OrderedDictionaryNonClassFriendlyNameTypeTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, true, className, propName, false)]
        public void UnorderedDictionaryNonClassFriendlyNameTypeTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Set, true, className, propName, true)]
        public void SetDictionaryClassFriendlyNameTypeTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, true, className, propName, true)]
        public void OrderedDictionaryClassFriendlyNameTypeTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, true, className, propName, true)]
        public void UnorderedDictionaryClassFriendlyNameTypeTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Set, false, className, propName, false)]
        public void SetDictionaryNonClassCompleteNameTypeTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, false, className, propName, false)]
        public void OrderedDictionaryNonClassCompleteNameTypeTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, false, className, propName, false)]
        public void UnorderedDictionaryNonClassCompleteNameTypeTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Set, false, className, propName, true)]
        public void SetDictionaryClassCompleteNameTypeTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, false, className, propName, true)]
        public void OrderedDictionaryClassCompleteNameTypeTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, false, className, propName, true)]
        public void UnorderedDictionaryClassCompleteNameTypeTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }
    }
}