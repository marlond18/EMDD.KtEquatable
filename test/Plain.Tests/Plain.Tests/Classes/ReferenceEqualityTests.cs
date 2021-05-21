
using KtEquatable.Unit.Tests.Classes.TestDataSourceAttributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;

namespace KtEquatable.Unit.Tests.Classes
{
	[TestClass]
	public class ReferenceEqualityTests
	{
		private const string className = "B";
		private const string propName = "P2";

		[DataTestMethod]
		[RefDataSource(true, className, propName, true)]
		public void CorrectDataFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
		}

		[DataTestMethod]
		[RefDataSource(false, className, propName, true)]
		public void CorrectDataCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
		}

		[DataTestMethod]
		[RefDataSource(true, className, propName, false)]
		public void WrongDataFriendlyNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
		}

		[DataTestMethod]
		[RefDataSource(false, className, propName, false)]
		public void WrongDataCompleteNameTest(SourceClass sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
		}
	}
}