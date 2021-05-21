using EMDD.KtEquatable.Core;

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using static EMDD.KtEquatable.Core.CoreHelpers;

namespace EMDD.KtEquatable.Syntax
{
    public class RecordSyntax : EquatableTypeSyntax
    {
        public override void BuildString(IndentedTextWriter indented)
        {
            //using var stringwritter = new StringWriter();
            //using var indented = new IndentedTextWriter(stringwritter, Indention);

            indented.WriteLine($"partial record {Name}");
            indented.WriteLine("{");
            indented.WriteLineNoTabs("#nullable enable");
            indented.Indent++;
            Equality(indented);
            indented.WriteLine();
            indented.WriteLine();
            Hash(indented);
            indented.WriteLine();
            indented.WriteLineNoTabs("#nullable restore");
            indented.Indent--;
            indented.Write("}");

            //return stringwritter.ToString();
        }

        protected override bool UseBase() => !BaseType.IsBaseObject;

        protected override void FSE(IndentedTextWriter writer)
        {
            writer.Write(UseBase() ? $"base.Equals(other as {BaseType.Name})" : "EqualityContract == other.EqualityContract");
        }

        protected override void FSH(IndentedTextWriter writer)
        {
            writer.Write(UseBase() ? "hashCode.Add(base.GetHashCode());" : "hashCode.Add(this.GetType());");
        }
    }
}