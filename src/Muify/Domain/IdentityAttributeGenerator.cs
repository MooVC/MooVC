namespace Muify.Domain
{
    using System.Text;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Text;

    [Generator]
    public sealed class IdentityAttributeGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            context.RegisterPostInitializationOutput(GenerateIdentityAttribute);
        }

        private static void GenerateIdentityAttribute(IncrementalGeneratorPostInitializationContext context)
        {
            context.AddSource(
                "Muify.Domain.IdentityAttribute.g.cs",
                SourceText.From(IdentityAttributeGenerator_Resources.DefinitionIdentityAttributeGeneration, Encoding.UTF8));
        }
    }
}