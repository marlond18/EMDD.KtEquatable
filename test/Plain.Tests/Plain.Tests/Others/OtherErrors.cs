using EMDD.KtEquatable.Core;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KtEquatable.Unit.Tests.Classes
{
	[TestClass]
	public class OtherErrors
	{
		[TestMethod]
		public void StaticClassTest()
		{
			var (diagnostics, content) = TestGeneratorHelper.GetGeneratedOutput(
@"using EMDD.KtEquatable.Core.Attributes;

namespace Test
{
	[Equatable]
	public static class A
	{
		public string? P1 { get; set; }
	}
}");
			var (id, title, desc, severity) = DiagnosticData.StaticClass(null);
			Assert.AreEqual(diagnostics.Length, 1);
			Assert.AreEqual(diagnostics[0].Descriptor.Id, id);
			Assert.AreEqual(diagnostics[0].Descriptor.Title, title);
			Assert.AreEqual(diagnostics[0].Descriptor.DefaultSeverity, severity);
		}
	}
}