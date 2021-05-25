
using EMDD.KtEquatable.Core.Attributes;

using KtEquatable.Unit.Tests.Assertions;
using KtEquatable.Unit.Tests.Assertions.TestDataSourceAttributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;

namespace KtEquatable.Unit.Tests.Structs.EnumerableTests
{
    [TestClass]
    public class ReferenceEqualityComparerTests
    {
        private const string objName = "Data";
        private const string propName = "P1";
        private const bool skipEqOp = false;
        private const bool forIgnoreAtt = false;

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set, true, objName, propName,false, typeof(SourceStruct))]
        public void SetNonClassTypeFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set, true, objName, propName,false, typeof(SourceStruct))]
        public void OrderedNonClassTypeFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, true, objName, propName, false, typeof(SourceStruct))]
        public void UnorderedNonClassTypeFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set,false, objName, propName, false, typeof(SourceStruct))]
        public void SetNonClassTypeCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Ordered, false, objName, propName, false, typeof(SourceStruct))]
        public void OrderedNonClassTypeCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, false, objName, propName, false, typeof(SourceStruct))]
        public void UnorderedNonClassTypeCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set, true, objName, propName, true, typeof(SourceStruct))]
        public void SetClassTypeFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Ordered, true, objName, propName, true, typeof(SourceStruct))]
        public void OrderedClassTypeFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, true, objName, propName, true, typeof(SourceStruct))]
        public void UnorderedClassTypeFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Set, false, objName, propName, true, typeof(SourceStruct))]
        public void SetClassTypeCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Ordered, false, objName, propName, true, typeof(SourceStruct))]
        public void OrderedClassTypeCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [EnumerableRefDataSource(EnumerableOrderType.Unordered, false, objName, propName, true, typeof(SourceStruct))]
        public void UnorderedClassTypeCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource( EnumerableOrderType.Set,true, objName,propName,false, typeof(SourceStruct))]
        public void SetDictionaryNonClassFriendlyNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, true, objName, propName, false, typeof(SourceStruct))]
        public void OrderedDictionaryNonClassFriendlyNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, true, objName, propName, false, typeof(SourceStruct))]
        public void UnorderedDictionaryNonClassFriendlyNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Set, true, objName, propName, true, typeof(SourceStruct))]
        public void SetDictionaryClassFriendlyNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, true, objName, propName, true, typeof(SourceStruct))]
        public void OrderedDictionaryClassFriendlyNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, true, objName, propName, true, typeof(SourceStruct))]
        public void UnorderedDictionaryClassFriendlyNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Set, false, objName, propName, false, typeof(SourceStruct))]
        public void SetDictionaryNonClassCompleteNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, false, objName, propName, false, typeof(SourceStruct))]
        public void OrderedDictionaryNonClassCompleteNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, false, objName, propName, false, typeof(SourceStruct))]
        public void UnorderedDictionaryNonClassCompleteNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Set, false, objName, propName, true, typeof(SourceStruct))]
        public void SetDictionaryClassCompleteNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Ordered, false, objName, propName, true, typeof(SourceStruct))]
        public void OrderedDictionaryClassCompleteNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }

        [DataTestMethod]
        [DictionaryRefDataSource(EnumerableOrderType.Unordered, false, objName, propName, true, typeof(SourceStruct))]
        public void UnorderedDictionaryClassCompleteNameTypeTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
        }
    }
}