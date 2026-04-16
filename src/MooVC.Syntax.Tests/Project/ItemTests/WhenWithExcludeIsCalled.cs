namespace MooVC.Syntax.Project.ItemTests;

public sealed class WhenWithExcludeIsCalled
{
    private const string UpdatedExclude = "UpdatedExclude";

    [Test]
    public async Task GivenExcludeThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = Snippet.From(UpdatedExclude);

        // Act
        Item result = original.WithExclude(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Exclude).IsEqualTo(updated);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
        _ = await Assert.That(result.Include).IsEqualTo(original.Include);
    }
}