using KtEquatable.Unit.Tests.Assertions;
using KtEquatable.Unit.Tests.Assertions.TestDataSourceAttributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.Assertions.AssertionHelpers;

namespace KtEquatable.Unit.Tests.Records
{
	[TestClass]
	public class ReferenceEqualityTests
	{
		private const string className = "B";
		private const string propName = "P2";
		private const bool skipEqOp = true;
		private const bool forIgnoreAtt = false;

		[DataTestMethod]
		[RefDataSource(true, className, propName, true, typeof(SourceRecord))]
		public void CorrectDataFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
		}

		[DataTestMethod]
		[RefDataSource(false, className, propName, true, typeof(SourceRecord))]
		public void CorrectDataCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
		}

		[DataTestMethod]
		[RefDataSource(true, className, propName, false, typeof(SourceRecord))]
		public void WrongDataFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
		}

		[DataTestMethod]
		[RefDataSource(false, className, propName, false, typeof(SourceRecord))]
		public void WrongDataCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, className, propName, skipEqOp, forIgnoreAtt);
		}
	}
}