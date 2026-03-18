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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Items).IsEqualTo(original.Items.Concat([additional]));
        await Assert.That(result.Files).IsEqualTo(original.Files);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Projects).IsEqualTo(original.Projects);
    }
}