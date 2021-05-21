using EMDD.KtEquatable.Syntax.Property;

using System.CodeDom.Compiler;
using System.Collections.Generic;

using static EMDD.KtEquatable.Core.CoreHelpers;

namespace EMDD.KtEquatable.Syntax
{
    public abstract class EquatableTypeSyntax : TypeSyntax
    {
        public string Name { get; set; }

        public BaseType BaseType { get; set; }

        public bool IsAbstract { get; set; }

        internal string VirtualOrNot => IsSealed ? "" : " virtual";

        public bool IsSealed { get; set; }

        public List<PropertyDefaultEquality> PropertiesSytax { get; set; } = new List<PropertyDefaultEquality>();

        protected void Equality(IndentedTextWriter writer)
        {
            writer.WriteLine(GeneratedCodeAttributeDeclaration);
            writer.WriteLine($"public{VirtualOrNot} bool Equals({Name}? other)");
            writer.WriteLine("{");
            writer.Indent++;
            writer.WriteLine("if (ReferenceEquals(this, other)) return true;");
            writer.WriteLine("if (other is null ||this is null) return false;");
            writer.Write("return ");
            FSE(writer);
            writer.Indent++;
            foreach (var p in PropertiesSytax)
            {
                writer.WriteLine();
                writer.Write(p.EqualityString());
            }
            writer.WriteLine(";");
            writer.Indent--;
            writer.Indent--;
            writer.Write("}");
        }

        protected void Hash(IndentedTextWriter writer)
        {
            writer.WriteLine(InheritDocComment);
            writer.WriteLine(GeneratedCodeAttributeDeclaration);
            writer.WriteLine("public override int GetHashCode()");
            writer.WriteLine("{");
            writer.Indent++;
            writer.WriteLine("var hashCode = new HashCode();");
            FSH(writer);
            foreach (var p in PropertiesSytax)
            {
                writer.WriteLine();
                writer.Write($"{p.HashCodeString()};");
            }
            writer.WriteLine();
            writer.WriteLine("return hashCode.ToHashCode();");
            writer.Indent--;
            writer.Write("}");
        }

        protected abstract bool UseBase();
        protected abstract void FSE(IndentedTextWriter writer);
        protected abstract void FSH(IndentedTextWriter writer);
    }
}