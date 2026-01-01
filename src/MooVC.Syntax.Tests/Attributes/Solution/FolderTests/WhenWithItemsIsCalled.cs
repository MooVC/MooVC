namespace MooVC.Syntax.Attributes.Solution.FolderTests;

using System.Linq;
using MooVC.Syntax.Elements;

public sealed class WhenWithItemsIsCalled
{
    [Fact]
    public void GivenItemsThenReturnsUpdatedInstance()
    {
        // Arrange
        Item existing = FolderTestsData.CreateItem();
        Item additional = FolderTestsData.CreateItem().WithName(Snippet.From("OtherItem"));
        Folder original = FolderTestsData.Create(item: existing);

        // Act
        Folder result = original.WithItems(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Items.ShouldBe(original.Items.Concat([additional]));
        result.Files.ShouldBe(original.Files);
        result.Folders.ShouldBe(original.Folders);
        result.Id.ShouldBe(original.Id);
        result.Name.ShouldBe(original.Name);
    }
}