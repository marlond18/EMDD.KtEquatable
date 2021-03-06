using EMDD.KtEquatable.Core.Attributes;

using Microsoft.CodeAnalysis;
namespace EMDD.KtEquatable
{
    [Generator]
    public class ResourceAttributeGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForPostInitialization(cc =>
            {
                cc.AddSource("EquatableAttribute.g.cs", AttributeWriter.EquatableAttribute());
                cc.AddSource("EnumerableEqualityAttribute.g.cs", AttributeWriter.EnumerableEqualityAttribute());
                cc.AddSource("IgnoreEqualityAttribute.g.cs", AttributeWriter.IgnoreEqualityAttribute());
                cc.AddSource("ReferenceEqualityAttribute.g.cs", AttributeWriter.ReferenceEqualityAttribute());
                cc.AddSource("FloatingPointEqualityAttribute.g.cs", AttributeWriter.FloatingPointEqualityAttribute());
            });
        }
    }
}
