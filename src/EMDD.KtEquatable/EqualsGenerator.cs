using EMDD.KtSourceGen.KtEquatable.Core;
using EMDD.KtSourceGen.KtEquatable.Syntax;
using EMDD.KtSourceGen.KtEquatable.Syntax.Property;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

using System;
using System.Collections.Generic;
using System.Text;

using static EMDD.KtSourceGen.KtEquatable.Core.CoreHelpers;
using static EMDD.KtSourceGen.KtEquatable.Syntax.SyntaxGenerators;
namespace EMDD.KtSourceGen.KtEquatable
{
    [Generator]
    internal class EqualsGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            //#if DEBUG
            //            Debugger.Launch();
            //#endif
            context.RegisterForPostInitialization((i) =>
            {
                i.AddSource($"{SourceGenName}.Attributes", AttributeTypeSymbolCollection.AttributeCode);
                i.AddSource($"{SourceGenName}.EqualityComparers", PropertyHasCustomComparer.EqualityComparerText());
            });
            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxReceiver is not SyntaxReceiver s) return;
            var attrCollection = AttributeTypeSymbolCollection.Create(context);
            foreach (var node in s.CandidateSyntaxes)
            {
                var symbol = context.GetSymbol(node);
                if (!symbol.HasAttribute(attrCollection.Equatable)) continue;
                var (name, baseType) = symbol.GetDeclarationNames();
                TypeSyntaxWithProps type = node switch
                {
                    RecordDeclarationSyntax _ => new RecordSyntax { Name = name, BaseType = baseType, IsSealed = symbol.IsSealed, TypeDec = "record" },
                    ClassDeclarationSyntax _ => new ClassSyntax() { BaseType = baseType, Name = name },
                    _ => throw new Exception("Type does not exist, Struct Type soon to be included, or a PR would be nice too.")
                };
                var isRecord = node is RecordDeclarationSyntax;
                foreach (var property in symbol.GetProperties())
                {
                    var p = attrCollection.ToPropertyEquality(property, isRecord);
                    if (p is PropertyDefaultEquality d)
                    {
                        type.PropertiesSytax.Add(d);
                    }
                }
                var parent = type.AssignAndGetParent(symbol);
                context.AddSource($"{symbol!.ToDisplayString().ReplaceEscapeChars()}.{SourceGenName}.g.cs"!, SourceText.From(parent.BuildString(), Encoding.UTF8));
            }
        }

        private class SyntaxReceiver : ISyntaxReceiver
        {
            private readonly List<SyntaxNode> _candidateSyntaxes = new();

            public IReadOnlyList<SyntaxNode> CandidateSyntaxes => _candidateSyntaxes;

            public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
            {
                if (syntaxNode is not ClassDeclarationSyntax and not RecordDeclarationSyntax) return;
                _candidateSyntaxes.Add(syntaxNode);
            }
        }
    }
}
