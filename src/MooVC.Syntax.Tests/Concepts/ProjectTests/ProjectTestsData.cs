namespace MooVC.Syntax.Concepts.ProjectTests;

using MooVC.Syntax.Attributes.Project;
using MooVC.Syntax.Elements;

internal static class ProjectTestsData
{
    public const string DefaultImportProject = "Project";
    public const string DefaultItemInclude = "Include";
    public const string DefaultPropertyName = "Property";
    public const string DefaultPropertyValue = "Value";
    public const string DefaultSdkVersion = "1.0.0";
    public const string DefaultTargetName = "Build";
    public static readonly Qualifier DefaultSdkName = "MooVC.Sdk";

    public static Project Create(
        Import? import = default,
        ItemGroup? itemGroup = default,
        PropertyGroup? propertyGroup = default,
        Sdk? sdk = default,
        Target? target = default)
    {
        return Builder
            .New<Project>()
            .ForkOn(
                _ => import is null,
                @true: project => project.WithImports(import => import
                    .WithProject(DefaultImportProject)),
                @false: project => project.WithImports(import))
            .ForkOn(
                _ => itemGroup is null,
                @true: project => project.WithItemGroups(group => group
                    .WithItems(item => item
                        .WithInclude(DefaultItemInclude))),
                @false: project => project.WithItemGroups(itemGroup))
            .ForkOn(
                _ => propertyGroup is null,
                @true: project => project.WithPropertyGroups(group => group
                    .WithProperties(property => property
                        .WithName(DefaultPropertyName)
                        .WithValue(DefaultPropertyValue))),
                @false: project => project.WithPropertyGroups(propertyGroup))
            .ForkOn(
                _ => sdk is null,
                @true: project => project.WithSdks(sdk => sdk
                    .WithName(DefaultSdkName)
                    .WithVersion(DefaultSdkVersion)),
                @false: project => project.WithSdks(sdk))
            .ForkOn(
                _ => target is null,
                @true: project => project.WithTargets(target => target
                    .WithName(DefaultTargetName)),
                @false: project => project.WithTargets(target));
    }

    public static Import CreateImport()
    {
        return new Import
        {
            Project = Snippet.From(DefaultImportProject),
        };
    }

    public static ItemGroup CreateItemGroup()
    {
        return new ItemGroup
        {
            Items = [new Item { Include = Snippet.From(DefaultItemInclude) }],
        };
    }

    public static PropertyGroup CreatePropertyGroup()
    {
        return new PropertyGroup
        {
            Properties = [new Property { Name = new Identifier(DefaultPropertyName), Value = Snippet.From(DefaultPropertyValue) }],
        };
    }

    public static Sdk CreateSdk()
    {
        return new Sdk
        {
            Name = DefaultSdkName,
            Version = Snippet.From(DefaultSdkVersion),
        };
    }

    public static Target CreateTarget()
    {
        return new Target
        {
            Name = new Identifier(DefaultTargetName),
        };
    }
}