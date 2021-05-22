using EMDD.KtEquatable;
using EMDD.KtEquatable.Core;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

using static EMDD.KtEquatable.Core.DiagnosticData;

namespace KtEquatable.Unit.Tests
{
    internal abstract class IfBase<T>
    {
        internal readonly T o;

        protected IfBase(T o)
        {
            this.o = o;
        }
    }

    internal class IfString : IfBase<string>
    {
        public IfString(string o) : base(o)
        {
        }

        public IfString Contains(string s)
        {
            Assert.IsTrue(o.Contains(s), $"{o}\ndoes not contain\n{s}");
            return this;
        }
    }

    internal class IfGeneratedString : IfString
    {
        private readonly ImmutableArray<Diagnostic> diagnostics;

        public IfGeneratedString(ImmutableArray<Diagnostic> diag, string o) : base(o)
        {
            this.diagnostics = diag;
        }

        public void HasNoDiagnostics()
        {
            Assert.AreEqual(diagnostics.Length, 0);
        }

        private static readonly string Nl = System.Environment.NewLine;

        public void IsDiagnosedWith(TypeInfo<IPropertySymbol> diagTypeInfo)
        {
            var (id, title, _, severity) = diagTypeInfo(null);
            Assert.AreEqual(1, diagnostics.Length, $"The length of the diagnostics is not 1 but {diagnostics.Length}");
            Assert.AreEqual(id, diagnostics[0].Descriptor.Id, $"The expected diagnostic id is {id} but the actual is {diagnostics[0].Descriptor.Id}");
            Assert.AreEqual(title, diagnostics[0].Descriptor.Title, $"The expected diagnostic title is {title} but the actual is {diagnostics[0].Descriptor.Title}");
            Assert.AreEqual(severity, diagnostics[0].Descriptor.DefaultSeverity, $"the expected diagnostic severity is {severity}, but the actual is {diagnostics[0].Descriptor.DefaultSeverity}");
        }

        public void HasEqualsOperatorFor(string propType)
        {
            string eqOp = $"\t\tpublic static bool operator ==({propType}? left, {propType}? right) =>{Nl}\t\t\tEqualityComparer<{propType}>.Default.Equals(left, right);";
            Assert.IsTrue(o.Contains(eqOp), $"Generated does not contain\n{eqOp}.\n{o}");
        }

        public void HasPartialClassHeaderFor(string s)
        {
            Assert.IsTrue(o.Contains($"{Nl}{{{Nl}\tpartial class {s} : IEquatable<{s}>{Nl}\t"), $"class {s} is not marked as partial properly.");
        }

        public void HasPartialRecordHeaderFor(string s)
        {
            Assert.IsTrue(o.Contains($"{Nl}{{{Nl}\tpartial record {s}{Nl}\t"), $"record {s} is not marked as partial properly.");
        }

        public void HasCorrectUsingStatements()
        {
            Assert.IsTrue(o.Contains($"using System;{Nl}using System.Collections.Generic;{Nl}using System.CodeDom.Compiler;{Nl}using EMDD.KtEquatable.Core.EqualityComparers;{Nl}namespace Test{Nl}"), "wrong using statements.");
        }

        public void HasNullableSyntax()
        {
            Assert.IsTrue(o.Contains("{Nl}#nullable restore{Nl}"), "nullable restore is not present.");
            Assert.IsTrue(o.Contains("{Nl}#nullable enable{Nl}"), "nullable enable is not present.");
        }

        public void HasEqualityComparerFor(string p, string comparer)
        {
            Assert.IsTrue(o.Contains($"{Nl}\t\t\t\t&& {comparer}.Equals({p}!, other.{p}!);"), $"{p} was not compared using {comparer} in the equals method.");
            Assert.IsTrue(o.Contains($"{Nl}\t\t\thashCode.Add(this.{p}!, {comparer});{Nl}\t\t\t"), $"No hashcode added for {p} using {comparer}.");
        }

        public void IgnoresEqualityComparerFor(string p, string comparer)
        {
            Assert.IsTrue(!o.Contains($"{Nl}\t\t\t\t&& {comparer}.Equals({p}!, other.{p}!);"), $"{p} was not compared using {comparer} in the equals method.");
            Assert.IsTrue(!o.Contains($"{Nl}\t\t\thashCode.Add(this.{p}!, {comparer});{Nl}\t\t\t"), $"No hashcode added for {p} using {comparer}.");
        }
    }

    internal static class Test
    {
        internal static IfString If(string s)
        {
            return new IfString(s);
        }
        internal static IfGeneratedString IfGeneratedString(ImmutableArray<Diagnostic> diag, string s)
        {
            return new IfGeneratedString(diag, s);
        }
    }
}
