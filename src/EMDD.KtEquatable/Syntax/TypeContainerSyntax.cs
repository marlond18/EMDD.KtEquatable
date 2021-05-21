using EMDD.KtEquatable.Core;

using System.CodeDom.Compiler;
using System.Linq;

namespace EMDD.KtEquatable.Syntax
{
    public class TypeContainerSyntax : TypeSyntax
    {
        public string TypeDec { get; set; }

        public string Name { get; set; }

        public override void BuildString(IndentedTextWriter writer)
        {
            writer.WriteLine($"partial {TypeDec} {Name}");
            writer.Write("{");
            writer.Indent++;
            foreach (var child in Children)
            {
                writer.WriteLine();
                child.BuildString(writer);
            }
            writer.WriteLine();
            writer.Indent--;
            writer.Write("}");

//            return $@"partial {TypeDec} {Name}
//{{
//{string.Join("\n", Children.Select(c => c.BuildString())).IndentAllLines(1, Indention)}
//}}";
        }
    }
}