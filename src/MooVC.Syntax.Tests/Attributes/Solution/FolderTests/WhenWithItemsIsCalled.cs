namespace MooVC.Syntax.Attributes.Solution.FolderTests;

using System.Linq;
using MooVC.Syntax.Elements;

public sealed class WhenWithItemsIsCalled
{
    [Test]
    public async Task GivenItemsThenReturnsUpdatedInstance()
    {
        // Arrange
        Item existing = FolderTestsData.CreateItem();
        Item additional = FolderTestsData.CreateItem().Named(Snippet.From("OtherItem"));
        Folder original = FolderTestsData.Create(item: existing);

        // Act
        Folder result = original.WithItems(additional);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Items).IsEqualTo(original.Items.Concat([additional]));
        _ = await Assert.That(result.Files).IsEqualTo(original.Files);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Projects).IsEqualTo(original.Projects);
    }
}