namespace MooVC.Syntax.Concepts.ProjectTests;

using MooVC.Syntax.Attributes.Project;
using MooVC.Syntax.Attributes.Resource;
using MooVC.Syntax.Concepts.ResourceTests;
using MooVC.Syntax.Elements;
using Resource = MooVC.Syntax.Attributes.Resource.Resource;

internal static class ProjectTestsData
{
    public const string DefaultImportProject = "Project";
    public const string DefaultItemInclude = "Include";
    public const string DefaultPropertyName = "Property";
    public const string DefaultPropertyValue = "Value";
    public const string DefaultDesignerPath = "Resources.Designer.cs";
    public const string DefaultLocation = "Resources.resx";
    public const string DefaultResourceToolNamespace = "MooVC.Resources";
    public const string DefaultSdkVersion = "1.0.0";
    public const string DefaultTargetName = "Build";
    public static readonly Qualifier DefaultSdkName = "MooVC.Sdk";

    public static Project Create(
        Import? import = default,
        ItemGroup? itemGroup = default,
        PropertyGroup? propertyGroup = default,
        Resource? resource = default,
        Sdk? sdk = default,
        Target? target = default)
    {
        return Builder
            .New<Project>()
            .ForkOn(
                _ => import is null,
                @true: project => project.WithImports(import => import
                    .ForProject(DefaultImportProject)),
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
                        .Named(DefaultPropertyName)
                        .WithValue(DefaultPropertyValue))),
                @false: project => project.WithPropertyGroups(propertyGroup))
            .ForkOn(
                _ => resource is null,
                @true: project => project.WithResources(resource => resource
                    .WithCustomToolNamespace(DefaultResourceToolNamespace)
                    .WithLocation(DefaultLocation)),
                @false: project => project.WithResources(resource))
            .ForkOn(
                _ => sdk is null,
                @true: project => project.WithSdks(sdk => sdk
                    .Named(DefaultSdkName)
                    .WithVersion(DefaultSdkVersion)),
                @false: project => project.WithSdks(sdk))
            .ForkOn(
                _ => target is null,
                @true: project => project.WithTargets(target => target
                    .Named(DefaultTargetName)),
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

    public static Resource CreateResource()
    {
        return new Resource
        {
            CustomToolNamespace = Snippet.From(DefaultResourceToolNamespace),
            Location = DefaultLocation,
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