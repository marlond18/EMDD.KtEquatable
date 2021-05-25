
using EMDD.KtEquatable.Core.Attributes;

using KtEquatable.Unit.Tests.Assertions;
using KtEquatable.Unit.Tests.Assertions.TestDataSourceAttributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;

namespace KtEquatable.Unit.Tests.Classes.EnumerableTests
{
    [TestClass]
    public class ReferenceEqualityComparerTests
    {
        private const string objName = "Data";
        private const string propName = "P1";
        private const bool skipEqOp = false;
        private const bool forIgnoreAtt = false;

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set, true, objName, propName,false, typeof(SourceClass))]
        public void SetNonClassTypeFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set, true, objName, propName,false, typeof(SourceClass))]
        public void OrderedNonClassTypeFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, true, objName, propName, false, typeof(SourceClass))]
        public void UnorderedNonClassTypeFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set,false, objName, propName, false, typeof(SourceClass))]
        public void SetNonClassTypeCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Ordered, false, objName, propName, false, typeof(SourceClass))]
        public void OrderedNonClassTypeCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, false, objName, propName, false, typeof(SourceClass))]
        public void UnorderedNonClassTypeCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set, true, objName, propName, true, typeof(SourceClass))]
        public void SetClassTypeFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Ordered, true, objName, propName, true, typeof(SourceClass))]
        public void OrderedClassTypeFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, true, objName, propName, true, typeof(SourceClass))]
        public void UnorderedClassTypeFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set, false, objName, propName, true, typeof(SourceClass))]
        public void SetClassTypeCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Ordered, false, objName, propName, true, typeof(SourceClass))]
        public void OrderedClassTypeCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, false, objName, propName, true, typeof(SourceClass))]
        public void UnorderedClassTypeCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource( EnumerableOrderType.Set,true, objName,propName,false, typeof(SourceClass))]
        public void SetDictionaryNonClassFriendlyNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, true, objName, propName, false, typeof(SourceClass))]
        public void OrderedDictionaryNonClassFriendlyNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, true, objName, propName, false, typeof(SourceClass))]
        public void UnorderedDictionaryNonClassFriendlyNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Set, true, objName, propName, true, typeof(SourceClass))]
        public void SetDictionaryClassFriendlyNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, true, objName, propName, true, typeof(SourceClass))]
        public void OrderedDictionaryClassFriendlyNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, true, objName, propName, true, typeof(SourceClass))]
        public void UnorderedDictionaryClassFriendlyNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Set, false, objName, propName, false, typeof(SourceClass))]
        public void SetDictionaryNonClassCompleteNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, false, objName, propName, false, typeof(SourceClass))]
        public void OrderedDictionaryNonClassCompleteNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, false, objName, propName, false, typeof(SourceClass))]
        public void UnorderedDictionaryNonClassCompleteNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Set, false, objName, propName, true, typeof(SourceClass))]
        public void SetDictionaryClassCompleteNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, false, objName, propName, true, typeof(SourceClass))]
        public void OrderedDictionaryClassCompleteNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, false, objName, propName, true, typeof(SourceClass))]
        public void UnorderedDictionaryClassCompleteNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }
    }
}