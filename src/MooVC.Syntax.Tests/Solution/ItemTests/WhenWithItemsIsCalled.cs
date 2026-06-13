namespace MooVC.Syntax.Solution.ItemTests;

public sealed class WhenWithItemsIsCalled
{
    [Test]
    public async Task GivenItemsThenReturnsUpdatedInstance()
    {
        // Arrange
        Item existing = ItemTestsData.CreateChild();
        Item additional = ItemTestsData.CreateChild().WithId(Snippet.From("Other"));
        Item original = ItemTestsData.Create(item: existing);

        // Act
        Item result = original.WithItems(additional);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Items).IsEquivalentTo([.. original.Items, additional]);
        _ = await Assert.That(result.Id).IsEqualTo(original.Id);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Path).IsEqualTo(original.Path);
        _ = await Assert.That(result.Type).IsEqualTo(original.Type);
    }
}