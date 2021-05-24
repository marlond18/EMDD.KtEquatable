
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
    public class ReferenceEqualityComparerTests
    {
        private const string className = "Data";
        private const string propName = "P1";
        private const bool skipEqOp = true;
        private const bool forIgnoreAtt = false;

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set, true, className, propName,false, typeof(SourceRecord))]
        public void SetNonClassTypeFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Ordered, true, className, propName, false, typeof(SourceRecord))]
        public void OrderedNonClassTypeFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, true, className, propName, false, typeof(SourceRecord))]
        public void UnorderedNonClassTypeFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set,false, className, propName, false, typeof(SourceRecord))]
        public void SetNonClassTypeCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Ordered, false, className, propName, false, typeof(SourceRecord))]
        public void OrderedNonClassTypeCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, false, className, propName, false, typeof(SourceRecord))]
        public void UnorderedNonClassTypeCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set, true, className, propName, true, typeof(SourceRecord))]
        public void SetClassTypeFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Ordered, true, className, propName, true, typeof(SourceRecord))]
        public void OrderedClassTypeFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, true, className, propName, true, typeof(SourceRecord))]
        public void UnorderedClassTypeFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set, false, className, propName, true, typeof(SourceRecord))]
        public void SetClassTypeCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Ordered, false, className, propName, true, typeof(SourceRecord))]
        public void OrderedClassTypeCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, false, className, propName, true, typeof(SourceRecord))]
        public void UnorderedClassTypeCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource( EnumerableOrderType.Set,true, className,propName,false, typeof(SourceRecord))]
        public void SetDictionaryNonClassFriendlyNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, true, className, propName, false, typeof(SourceRecord))]
        public void OrderedDictionaryNonClassFriendlyNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, true, className, propName, false, typeof(SourceRecord))]
        public void UnorderedDictionaryNonClassFriendlyNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Set, true, className, propName, true, typeof(SourceRecord))]
        public void SetDictionaryClassFriendlyNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, true, className, propName, true, typeof(SourceRecord))]
        public void OrderedDictionaryClassFriendlyNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, true, className, propName, true, typeof(SourceRecord))]
        public void UnorderedDictionaryClassFriendlyNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Set, false, className, propName, false, typeof(SourceRecord))]
        public void SetDictionaryNonClassCompleteNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, false, className, propName, false, typeof(SourceRecord))]
        public void OrderedDictionaryNonClassCompleteNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, false, className, propName, false, typeof(SourceRecord))]
        public void UnorderedDictionaryNonClassCompleteNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Set, false, className, propName, true, typeof(SourceRecord))]
        public void SetDictionaryClassCompleteNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, false, className, propName, true, typeof(SourceRecord))]
        public void OrderedDictionaryClassCompleteNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, false, className, propName, true, typeof(SourceRecord))]
        public void UnorderedDictionaryClassCompleteNameTypeTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
        }
    }
}