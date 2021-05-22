﻿using KtEquatable.Unit.Tests.Records.TestDataSourceAttributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;

namespace KtEquatable.Unit.Tests.Records
{
    [TestClass]
    public class FloatingPointAttributeTests
    {
        private const string className = "B";
        private const string propName = "P2";

        [DataTestMethod]
        [FloatDataSource(-1, true, className, propName, true)]
        public void FloatNegativeFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [FloatDataSource(-1, false, className, propName, true)]
        public void FloatNegativeCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [FloatDataSource(-1, true, className, propName, false)]
        public void WrongDataFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [FloatDataSource(-1, false, className, propName, false)]
        public void WrongDataCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [FloatDataSource(10, true, className, propName, true)]
        public void FriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }

        [DataTestMethod]
        [FloatDataSource(10, false, className, propName, true)]
        public void CompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
        }
    }
}