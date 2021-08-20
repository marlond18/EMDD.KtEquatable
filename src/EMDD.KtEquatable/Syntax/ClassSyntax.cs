using EMDD.KtEquatable.Core;

using System.CodeDom.Compiler;

using static EMDD.KtEquatable.Core.CoreHelpers;

namespace EMDD.KtEquatable.Syntax
{
#nullable enable
    public class ClassSyntax : EquatableTypeSyntax
    {
        public override void BuildString(IndentedTextWriter indented)
        {
            indented.WriteLine($"partial class {Name} :{(string.IsNullOrEmpty(BaseType.Name) || BaseType.Name=="object" ? "" : " " + BaseType.Name + ",")} IEquatable<{Name}>");
            indented.WriteLine("{");
            indented.WriteLineNoTabs("#nullable enable");
            indented.Indent++;
            indented.AddSummary(SummaryGenerators.EqualOpSummary);
            indented.WriteLine(GeneratedCodeAttributeDeclaration);
            indented.WriteLine($"public static bool operator ==({Name}? left, {Name}? right) =>");
            indented.WriteLine($"\tEqualityComparer<{Name}>.Default.Equals(left, right);");
            indented.WriteLine();
            indented.AddSummary(SummaryGenerators.NotEqualOpSummary);
            indented.WriteLine(GeneratedCodeAttributeDeclaration);
            indented.WriteLine($"public static bool operator !=({Name}? left, {Name}? right) =>");
            indented.WriteLine("\t!(left == right);");
            indented.WriteLine();
            indented.WriteLine(InheritDocComment);
            indented.WriteLine(GeneratedCodeAttributeDeclaration);
            indented.WriteLine("public override bool Equals(object? obj) =>");
            indented.WriteLine($"\tEquals(obj as {Name});");
            indented.WriteLine();
            Equality(indented);
            indented.WriteLine();
            if (BaseType.MarkedAsEquatable)
            {
                indented.WriteLine();
                indented.WriteLine(InheritDocComment);
                indented.WriteLine(GeneratedCodeAttributeDeclaration);
                indented.WriteLine($"public sealed override bool Equals({BaseType.Name}? other)");
                indented.WriteLine("{");
                indented.Indent++;
                indented.WriteLine($"return Equals(other as {Name});");
                indented.Indent--;
                indented.WriteLine("}");
            }
            indented.WriteLine();
            Hash(indented);
            indented.WriteLine();
            indented.Indent--;
            indented.WriteLineNoTabs("#nullable restore");
            indented.Write("}");
        }

        protected override bool UseBase() =>
            !BaseType.IsBaseObject && (BaseType.MarkedAsEquatable || BaseType.MarkedWithIEquatable);

        protected override void FSE(IndentedTextWriter writer)
        {
            writer.Write(UseBase() ? $"base.Equals(other as {BaseType.Name})" : "this.GetType() == other.GetType()");
        }

        protected override void FSH(IndentedTextWriter writer)
        {
            writer.Write(UseBase() ? "hashCode.Add(base.GetHashCode());" : "hashCode.Add(this.GetType());");
        }
    }
#nullable restore
}