namespace MooVC.Syntax.Solution.FolderTests;

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
        _ = await Assert.That(result.Items).IsEquivalentTo([.. original.Items, additional]);
        _ = await Assert.That(result.Files).IsEqualTo(original.Files);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Projects).IsEqualTo(original.Projects);
    }
}