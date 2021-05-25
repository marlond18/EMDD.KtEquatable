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
		private const string objName = "B";
		private const string propName = "P2";
		private const bool skipEqOp = true;
		private const bool forIgnoreAtt = false;

		[DataTestMethod]
		[RefDataSource(true, objName, propName, true, typeof(SourceRecord))]
		public void CorrectDataFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
		}

		[DataTestMethod]
		[RefDataSource(false, objName, propName, true, typeof(SourceRecord))]
		public void CorrectDataCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
		}

		[DataTestMethod]
		[RefDataSource(true, objName, propName, false, typeof(SourceRecord))]
		public void WrongDataFriendlyNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
		}

		[DataTestMethod]
		[RefDataSource(false, objName, propName, false, typeof(SourceRecord))]
		public void WrongDataCompleteNameTest(SourceRecord sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
		{
			sourceClass.AssertAGeneratedCode(comparerSyntax, diagnostic, objName, propName, skipEqOp, forIgnoreAtt);
		}
	}
}