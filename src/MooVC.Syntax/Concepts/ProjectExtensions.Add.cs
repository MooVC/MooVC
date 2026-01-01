namespace MooVC.Syntax.Concepts;

using System.Collections.Immutable;
using System.IO;
using Ardalis.GuardClauses;
using MooVC.Syntax.Attributes.Project;
using MooVC.Syntax.Elements;

public static partial class ProjectExtensions
{
    private const string AutoGenValue = "True";
    private const string DesignTimeValue = "True";
    private const string GeneratorValue = "ResXFileCodeGenerator";

    public static Project Add(this Project project, Resource resource, Snippet resourcePath, Snippet designerPath)
    {
        return project.Add(resource, resourcePath, designerPath, Snippet.Empty);
    }

    public static Project Add(this Project project, Resource resource, Snippet resourcePath, Snippet designerPath, Snippet customToolNamespace)
    {
        _ = Guard.Against.Null(project);
        _ = Guard.Against.Null(resource);
        _ = Guard.Against.Null(resourcePath);
        _ = Guard.Against.Null(designerPath);
        _ = Guard.Against.Null(customToolNamespace);

        if (resource.IsUndefined)
        {
            return project;
        }

        string resourcePathValue = resourcePath.ToString();
        string designerPathValue = designerPath.ToString();
        string dependentUpon = Path.GetFileName(resourcePathValue);

        ImmutableArray<Metadata> embeddedResourceMetadata = CreateEmbeddedResourceMetadata(designerPathValue, customToolNamespace);
        ImmutableArray<Metadata> compileMetadata = CreateCompileMetadata(dependentUpon);

        var embeddedResourceItem = new Item
        {
            Include = resourcePath,
            Metadata = embeddedResourceMetadata,
        };

        var compileItem = new Item
        {
            Include = designerPath,
            Metadata = compileMetadata,
        };

        var itemGroup = new ItemGroup
        {
            Items = [embeddedResourceItem, compileItem],
        };

        return project.WithItemGroups(itemGroup);
    }

    private static ImmutableArray<Metadata> CreateCompileMetadata(string dependentUpon)
    {
        return ImmutableArray.Create(
            new Metadata { Name = new Identifier("DependentUpon"), Value = Snippet.From(dependentUpon) },
            new Metadata { Name = new Identifier("DesignTime"), Value = Snippet.From(DesignTimeValue) },
            new Metadata { Name = new Identifier("AutoGen"), Value = Snippet.From(AutoGenValue) });
    }

    private static ImmutableArray<Metadata> CreateEmbeddedResourceMetadata(string designerPathValue, Snippet customToolNamespace)
    {
        var builder = ImmutableArray.CreateBuilder<Metadata>(3);

        builder.Add(new Metadata
        {
            Name = new Identifier("Generator"),
            Value = Snippet.From(GeneratorValue),
        });

        builder.Add(new Metadata
        {
            Name = new Identifier("LastGenOutput"),
            Value = Snippet.From(Path.GetFileName(designerPathValue)),
        });

        if (!customToolNamespace.IsEmpty)
        {
            builder.Add(new Metadata
            {
                Name = new Identifier("CustomToolNamespace"),
                Value = customToolNamespace,
            });
        }

        return builder.ToImmutable();
    }
}