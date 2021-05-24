
using KtEquatable.Unit.Tests.Assertions;
using KtEquatable.Unit.Tests.Assertions.TestDataSourceAttributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.Assertions.AssertionHelpers;

namespace KtEquatable.Unit.Tests.Classes
{
	[TestClass]
	public class ReferenceEqualityTests
	{
		private const string className = "B";
		private const string propName = "P2";

		[DataTestMethod]
		[RefDataSource(true, className, propName, true, typeof(SourceClass))]
		public void CorrectDataFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, false, false);
		}

		[DataTestMethod]
		[RefDataSource(false, className, propName, true, typeof(SourceClass))]
		public void CorrectDataCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, false, false);
		}

		[DataTestMethod]
		[RefDataSource(true, className, propName, false, typeof(SourceClass))]
		public void WrongDataFriendlyNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, false, false);
		}

		[DataTestMethod]
		[RefDataSource(false, className, propName, false, typeof(SourceClass))]
		public void WrongDataCompleteNameTest(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, false, false);
		}
	}
}