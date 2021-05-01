using System.Collections.Generic;

namespace EMDD.KtSourceGen.KtEquatable.Syntax
{
    public abstract class TypeSyntax
    {
        public TypeSyntax Parent { get; set; }

        public List<TypeSyntax> Children { get; } = new List<TypeSyntax>();

        public TypeSyntax GetRootParent()
        {
            return Parent is null ? this : Parent.GetRootParent();
        }

        public abstract string BuildString();
    }
}