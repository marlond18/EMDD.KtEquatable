using EMDD.KtEquatable.Core.Attributes;
using EMDD.KtEquatable.Syntax;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using System;
using System.Collections.Generic;

using static EMDD.KtEquatable.Syntax.SyntaxGenerators;

namespace EMDD.KtEquatable
{
    public class EquatableReceiver : ISyntaxContextReceiver
    {
        public List<(ClassDeclarationSyntax node, ITypeSymbol symbol)> ClassTypes { get; } = new();
        public List<(RecordDeclarationSyntax node, ITypeSymbol symbol)> RecordTypes { get; } = new();
        public List<(StructDeclarationSyntax node, ITypeSymbol symbol)> StructTypes { get; } = new();
        public List<(SyntaxNode node, ITypeSymbol symbol)> OtherTypes { get; } = new();

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            var syntaxNode = context.Node;
            var model = context.SemanticModel;
            var symbol = model.GetDeclaredSymbol(syntaxNode) as INamedTypeSymbol;
            var equatable = model.Compilation.GetTypeByMetadataName($"{AttributeWriter.AttrNamespace}.{AttributeWriter.EquatableAttributeName}")!;
            if (symbol.HasAttribute(equatable))
            {
                if (syntaxNode is ClassDeclarationSyntax cds)
                {
                    ClassTypes.Add((cds, symbol));
                }
                else if (syntaxNode is RecordDeclarationSyntax rds)
                {
                    RecordTypes.Add((rds, symbol));
                }
                else if(syntaxNode is StructDeclarationSyntax sds)
                {
                    StructTypes.Add((sds, symbol));
                }
                else
                {
                    OtherTypes.Add((syntaxNode, symbol));
                }
            }
        }
    }
}
