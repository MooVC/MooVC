namespace MooVC.Syntax.CSharp.Concepts.ProjectTests;

using MooVC.Syntax.CSharp.Attributes.Project;
using MooVC.Syntax.CSharp.Elements;

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
        var project = new Project();

        if (import is not null)
        {
            project = project.WithImports(import);
        }

        if (itemGroup is not null)
        {
            project = project.WithItemGroups(itemGroup);
        }

        if (propertyGroup is not null)
        {
            project = project.WithPropertyGroups(propertyGroup);
        }

        if (sdk is not null)
        {
            project = project.WithSdks(sdk);
        }

        if (target is not null)
        {
            project = project.WithTargets(target);
        }

        return project;
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