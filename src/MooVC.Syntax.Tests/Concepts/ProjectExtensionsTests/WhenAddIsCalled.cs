namespace MooVC.Syntax.Concepts.ProjectExtensionsTests;

using MooVC.Syntax.Attributes.Project;
using MooVC.Syntax.Concepts.ResourceTests;
using MooVC.Syntax.Elements;

public sealed class WhenAddIsCalled
{
    [Fact]
    public void GivenResourceThenAddsEmbeddedResourceItems()
    {
        // Arrange
        Resource resource = ResourceTestsData.Create();
        var project = new Project();
        Snippet resourcePath = Snippet.From("Resources/Strings.resx");
        Snippet designerPath = Snippet.From("Resources/Strings.Designer.cs");

        // Act
        Project result = project.Add(resource, resourcePath, designerPath);

        // Assert
        ItemGroup itemGroup = result.ItemGroups.ShouldHaveSingleItem();
        itemGroup.Items.Length.ShouldBe(2);

        Item embeddedResourceItem = itemGroup.Items[0];
        embeddedResourceItem.Include.ShouldBe(resourcePath);
        embeddedResourceItem.Metadata.ShouldBe(new[]
        {
            new Metadata { Name = new Identifier("Generator"), Value = Snippet.From("ResXFileCodeGenerator") },
            new Metadata { Name = new Identifier("LastGenOutput"), Value = Snippet.From("Strings.Designer.cs") },
        });

        Item compileItem = itemGroup.Items[1];
        compileItem.Include.ShouldBe(designerPath);
        compileItem.Metadata.ShouldBe(new[]
        {
            new Metadata { Name = new Identifier("DependentUpon"), Value = Snippet.From("Strings.resx") },
            new Metadata { Name = new Identifier("DesignTime"), Value = Snippet.From("True") },
            new Metadata { Name = new Identifier("AutoGen"), Value = Snippet.From("True") },
        });
    }


    [Fact]
    public void GivenUndefinedResourceThenReturnsOriginal()
    {
        // Arrange
        Resource resource = Resource.Undefined;
        var project = new Project();
        Snippet resourcePath = Snippet.From("Resources/Strings.resx");
        Snippet designerPath = Snippet.From("Resources/Strings.Designer.cs");

        // Act
        Project result = project.Add(resource, resourcePath, designerPath);

        // Assert
        result.ShouldBeSameAs(project);
        result.ItemGroups.ShouldBeEmpty();
    }

    [Fact]
    public void GivenExistingItemGroupsThenAppendsNewGroup()
    {
        // Arrange
        Resource resource = ResourceTestsData.Create();
        var existingGroup = new ItemGroup
        {
            Items = [new Item { Include = Snippet.From("Existing.cs") }],
        };
        var project = new Project { ItemGroups = [existingGroup] };
        Snippet resourcePath = Snippet.From("Resources/Strings.resx");
        Snippet designerPath = Snippet.From("Resources/Strings.Designer.cs");

        // Act
        Project result = project.Add(resource, resourcePath, designerPath);

        // Assert
        result.ItemGroups.Length.ShouldBe(2);
        result.ItemGroups[0].ShouldBe(existingGroup);
    }
    [Fact]
    public void GivenCustomToolNamespaceThenAddsCustomMetadata()
    {
        // Arrange
        Resource resource = ResourceTestsData.Create();
        var project = new Project();
        Snippet resourcePath = Snippet.From("Resources/Other.resx");
        Snippet designerPath = Snippet.From("Resources/Other.Designer.cs");
        Snippet customToolNamespace = Snippet.From("MooVC.Resources");

        // Act
        Project result = project.Add(resource, resourcePath, designerPath, customToolNamespace);

        // Assert
        ItemGroup itemGroup = result.ItemGroups.ShouldHaveSingleItem();
        Item embeddedResourceItem = itemGroup.Items[0];

        embeddedResourceItem.Metadata.ShouldBe(new[]
        {
            new Metadata { Name = new Identifier("Generator"), Value = Snippet.From("ResXFileCodeGenerator") },
            new Metadata { Name = new Identifier("LastGenOutput"), Value = Snippet.From("Other.Designer.cs") },
            new Metadata { Name = new Identifier("CustomToolNamespace"), Value = Snippet.From("MooVC.Resources") },
        });
    }
}