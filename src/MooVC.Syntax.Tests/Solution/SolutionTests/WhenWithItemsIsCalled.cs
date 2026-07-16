namespace MooVC.Syntax.Solution.SolutionTests;

public sealed class WhenWithItemsIsCalled
{
    [Test]
    public async Task GivenItemsThenReturnsUpdatedInstance()
    {
        // Arrange
        Item existing = SolutionTestsData.CreateItem();

        var additional = new Item
        {
            Id = Snippet.From("OtherId"),
            Name = Snippet.From("OtherName"),
            Path = Snippet.From("assets/other.txt"),
            Type = Snippet.From("OtherType"),
        };

        Solution original = SolutionTestsData.Create(item: existing);

        // Act
        Solution result = original.WithItems(additional);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Items).IsEquivalentTo([.. original.Items, additional]);
        _ = await Assert.That(result.Configurations).IsEqualTo(original.Configurations);
    }
}