using KtEquatable.Unit.Tests.Records.TestDataSourceAttributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;

namespace KtEquatable.Unit.Tests.Records
{
	[TestClass]
	public class ReferenceEqualityTests
	{
		private const string className = "B";
		private const string propName = "P2";

		[DataTestMethod]
		[RefDataSource(true, className, propName, true)]
		public void CorrectDataFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
		}

		[DataTestMethod]
		[RefDataSource(false, className, propName, true)]
		public void CorrectDataCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
		}

		[DataTestMethod]
		[RefDataSource(true, className, propName, false)]
		public void WrongDataFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
		}

		[DataTestMethod]
		[RefDataSource(false, className, propName, false)]
		public void WrongDataCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			AssertAGeneratedCode(sourceClass, comparerSyntax, diagnostic, className, propName);
		}
	}
}