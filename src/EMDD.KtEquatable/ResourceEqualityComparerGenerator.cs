using EMDD.KtEquatable.Core.EqualityComparers;

using Microsoft.CodeAnalysis;
namespace EMDD.KtEquatable
{
    [Generator]
    public class ResourceEqualityComparerGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForPostInitialization(cc =>
            {
                cc.AddSource("ComparerHelper.g.cs", EqualityComparerWriter.ComparerHelper());
                cc.AddSource("DictionaryEqualityComparer.g.cs", EqualityComparerWriter.DictionaryEqualityComparer());
                cc.AddSource("FloatingPointEqualityComparer.g.cs", EqualityComparerWriter.FloatingPointEqualityComparer());
                cc.AddSource("OrderedEqualityComparer.g.cs", EqualityComparerWriter.OrderedEqualityComparer());
                cc.AddSource("ReferenceEqualityComparer.g.cs", EqualityComparerWriter.ReferenceEqualityComparer());
                cc.AddSource("SetEqualityComparer.g.cs", EqualityComparerWriter.SetEqualityComparer());
                cc.AddSource("UnorderedEqualityComparer.g.cs", EqualityComparerWriter.UnorderedEqualityComparer());
            });
        }
    }
}
