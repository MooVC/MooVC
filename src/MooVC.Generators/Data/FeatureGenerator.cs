﻿namespace MooVC.Generators.Data;

using Microsoft.CodeAnalysis;

/// <summary>
/// Generates implementation elements for IFeature within an class or record that declares that it is an implementation.
/// Also generates an extension that supports consumption of the Feature through the prefix "With".
/// </summary>
[Generator(LanguageNames.CSharp)]
public sealed partial class FeatureGenerator
    : AttributeGenerator
{
    private const string TypeName = "IFeature";

    public FeatureGenerator()
        : base("With", TypeName)
    {
    }

    protected override string GenerateInstanceExtension(Attribute attribute)
    {
        return $$"""
                public static T With{{attribute.Name}}<T>(this T subject, {{attribute.Name}} attribute)
                    where T : IFeature<{{attribute.Name}}>
                {
                    return subject.With<{{attribute.Name}}, T>(attribute);
                }
            """;
    }

    protected override string GenerateMutatorExtension(Attribute attribute)
    {
        return $$"""
                public static T With{{attribute.Name}}<T>(this T subject, Mutator<{{attribute.Name}}> attribute)
                    where T : IFeature<{{attribute.Name}}>
                {
                    return subject.With<{{attribute.Name}}, T>(attribute);
                }
            """;
    }

    protected override string GenerateProperty(Subject subject)
    {
        return $$"""
            namespace {{subject.Namespace}};

            using {{subject.Attribute.Namespace}};
            using MooVC.Data;

            partial {{subject.Type}} {{subject.Name}}
            {
                {{subject.Attribute.Name}} IFeature<{{subject.Attribute.Name}}>.Attribute { get; set; }
            }
            """;
    }
}