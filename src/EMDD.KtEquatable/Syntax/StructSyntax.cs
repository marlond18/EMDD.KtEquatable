using EMDD.KtEquatable.Core;

using System.CodeDom.Compiler;

using static EMDD.KtEquatable.Core.CoreHelpers;

namespace EMDD.KtEquatable.Syntax
{
    public class StructSyntax : EquatableTypeSyntax
    {
        public override void BuildString(IndentedTextWriter indented)
        {
            indented.WriteLine($"partial struct {Name} : IEquatable<{Name}>");
            indented.WriteLine("{");
            indented.WriteLineNoTabs("#nullable enable");
            indented.Indent++;
            indented.AddSummary(SummaryGenerators.EqualOpSummary);
            indented.WriteLine(GeneratedCodeAttributeDeclaration);
            indented.WriteLine($"public static bool operator ==({Name} left, {Name} right) =>");
            indented.WriteLine($"\tEqualityComparer<{Name}>.Default.Equals(left, right);");
            indented.WriteLine();
            indented.AddSummary(SummaryGenerators.NotEqualOpSummary);
            indented.WriteLine(GeneratedCodeAttributeDeclaration);
            indented.WriteLine($"public static bool operator !=({Name} left, {Name} right) =>");
            indented.WriteLine("\t!(left == right);");
            indented.WriteLine();
            indented.WriteLine(InheritDocComment);
            indented.WriteLine(GeneratedCodeAttributeDeclaration);
            indented.WriteLine("public override bool Equals(object? obj) =>");
            indented.WriteLine($"\tobj is {Name} other && Equals(other);");
            indented.WriteLine();
            Equality(indented, false);
            indented.WriteLine();
            Hash(indented);
            indented.WriteLine();
            indented.Indent--;
            indented.WriteLineNoTabs("#nullable restore");
            indented.Write("}");
        }

        protected override bool UseBase() => false;

        protected override void FSE(IndentedTextWriter writer)
        {
            writer.Write("this.GetType() == other.GetType()");
        }

        protected override void FSH(IndentedTextWriter writer)
        {
            writer.Write("hashCode.Add(this.GetType());");
        }
    }

#nullable restore
}