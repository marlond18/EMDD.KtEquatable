
using EMDD.KtEquatable.Core.Attributes;

using KtEquatable.Unit.Tests.Records.TestDataSourceAttributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;

namespace KtEquatable.Unit.Tests.Records.EnumerableTests
{
    [TestClass]
    public class ReferenceEqualityComparerTests
    {
        private const string className = "Data";
        private const string propName = "P1";

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set, true, className, propName,false)]
        public void SetNonClassTypeFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Ordered, true, className, propName, false)]
        public void OrderedNonClassTypeFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, true, className, propName, false)]
        public void UnorderedNonClassTypeFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set,false, className, propName, false)]
        public void SetNonClassTypeCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Ordered, false, className, propName, false)]
        public void OrderedNonClassTypeCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, false, className, propName, false)]
        public void UnorderedNonClassTypeCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set, true, className, propName, true)]
        public void SetClassTypeFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Ordered, true, className, propName, true)]
        public void OrderedClassTypeFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, true, className, propName, true)]
        public void UnorderedClassTypeFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set, false, className, propName, true)]
        public void SetClassTypeCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Ordered, false, className, propName, true)]
        public void OrderedClassTypeCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, false, className, propName, true)]
        public void UnorderedClassTypeCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource( EnumerableOrderType.Set,true, className,propName,false )]
        public void SetDictionaryNonClassFriendlyNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, true, className, propName, false)]
        public void OrderedDictionaryNonClassFriendlyNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, true, className, propName, false)]
        public void UnorderedDictionaryNonClassFriendlyNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Set, true, className, propName, true)]
        public void SetDictionaryClassFriendlyNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, true, className, propName, true)]
        public void OrderedDictionaryClassFriendlyNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, true, className, propName, true)]
        public void UnorderedDictionaryClassFriendlyNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Set, false, className, propName, false)]
        public void SetDictionaryNonClassCompleteNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, false, className, propName, false)]
        public void OrderedDictionaryNonClassCompleteNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, false, className, propName, false)]
        public void UnorderedDictionaryNonClassCompleteNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Set, false, className, propName, true)]
        public void SetDictionaryClassCompleteNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, false, className, propName, true)]
        public void OrderedDictionaryClassCompleteNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, false, className, propName, true)]
        public void UnorderedDictionaryClassCompleteNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }
    }
}