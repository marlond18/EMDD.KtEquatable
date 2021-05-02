using EMDD.KtEquatable.Core;

using System.Linq;

namespace EMDD.KtSourceGen.KtEquatable.Syntax
{
    public class NameSpaceContainerSyntax : TypeSyntax
    {
        public string Name { get; set; }

        public override string BuildString()
        {
            return $@"namespace {Name}
{{
    {string.Join("\n", Children.Select(c => c.BuildString())).IndentNextLines(1)}
}}";
        }
    }
}
