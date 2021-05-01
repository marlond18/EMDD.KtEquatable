using EMDD.KtSourceGen.KtEquatable.Core;

using System.Linq;

namespace EMDD.KtSourceGen.KtEquatable.Syntax
{
    public class TypeContainerSyntax : TypeSyntax
    {
        public string TypeDec { get; set; }

        public string Name { get; set; }

        public override string BuildString()
        {
            return $@"partial {TypeDec} {Name}
{{
    {string.Join("\n", Children.Select(c => c.BuildString())).IndentNextLines(1)}
}}";
        }
    }
}