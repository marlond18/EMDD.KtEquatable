using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace EMDD.KtEquatable.Syntax
{
    public abstract class TypeSyntax
    {
        public TypeSyntax Parent { get; set; }

        public List<TypeSyntax> Children { get; } = new List<TypeSyntax>();

        public TypeSyntax GetRootParent()
        {
            return Parent is null ? this : Parent.GetRootParent();
        }

        public abstract void BuildString(IndentedTextWriter writer);
    }
}