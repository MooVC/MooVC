namespace MooVC.Generators.Data;

using Microsoft.CodeAnalysis;

/// <summary>
/// Generates implementation elements for IFeature within an class or record that declares that it is an implementation.
/// Also generates an extension that supports consumption of the Feature through the prefix "With".
/// </summary>
[Generator(LanguageNames.CSharp)]
public sealed partial class FeaturesGenerator
    : AttributeGenerator
{
    private const string TypeName = "IFeatures";

    public FeaturesGenerator()
        : base("Includes", TypeName)
    {
    }

    protected override string GenerateInstanceExtension(Attribute attribute)
    {
        return $$"""
                public static T Includes{{attribute.Name}}<T>(this T subject, params {{attribute.Name}}[] attributes)
                    where T : IFeatures<{{attribute.Name}}>
                {
                    return subject.Includes<{{attribute.Name}}, T>(attributes);
                }
            """;
    }

    protected override string GenerateMutatorExtension(Attribute attribute)
    {
        return $$"""
                public static T Includes{{attribute.Name}}<T>(this T subject, Mutator<{{attribute.Name}}> attribute)
                    where T : IFeatures<{{attribute.Name}}>
                {
                    return subject.Includes<{{attribute.Name}}, T>(attribute);
                }
            """;
    }

    protected override string GenerateProperty(Subject subject)
    {
        return $$"""
            namespace {{subject.Namespace}};

            using System.Collections.ObjectModel;
            using {{subject.Attribute.Namespace}};
            using MooVC.Data;

            partial {{subject.Type}} {{subject.Name}}
            {
                Collection<{{subject.Attribute.Name}}> IFeatures<{{subject.Attribute.Name}}>.Attributes { get; } = [];
            }
            """;
    }
}