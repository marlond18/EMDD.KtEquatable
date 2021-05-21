using EMDD.KtEquatable.Core;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KtEquatable.Unit.Tests.Classes
{
	[TestClass]
	public class OtherWarning
	{
		[TestMethod]
		public void RedundantIEquatable()
		{
			var (diagnostics, content) = TestGeneratorHelper.GetGeneratedOutput(
@"using EMDD.KtEquatable.Core.Attributes;

namespace Test
{
	[Equatable]
	public partial class B:System.IEquatable<B>
	{
		public string? P2 { get; set; }

		public bool Equals(B other)
		{
			return P2==other.P2;
		}
	}
}");
			var (id, title, desc, severity) = DiagnosticData.RedundantIEquatable(null);
			Assert.AreEqual(diagnostics.Length, 1);
			Assert.AreEqual(diagnostics[0].Descriptor.Id, id);
			Assert.AreEqual(diagnostics[0].Descriptor.Title, title);
			Assert.AreEqual(diagnostics[0].Descriptor.DefaultSeverity, severity);
		}

		[TestMethod]
		public void BaseNotIEquatable()
		{
			var (diagnostics, content) = TestGeneratorHelper.GetGeneratedOutput(
@"using EMDD.KtEquatable.Core.Attributes;

namespace Test
{
	public class A
	{
		public string? P1 { get; set; }
	}

	[Equatable]
	public partial class B:A
	{
		public string? P2 { get; set; }
	}
}");
			var (id, title, desc, severity) = DiagnosticData.BaseNonIEquatable(null);
			Assert.AreEqual(diagnostics.Length, 1);
			Assert.AreEqual(diagnostics[0].Descriptor.Id, id);
			Assert.AreEqual(diagnostics[0].Descriptor.Title, title);
			Assert.AreEqual(diagnostics[0].Descriptor.DefaultSeverity, severity);
		}
	}
}
