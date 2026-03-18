namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Exclude).IsEqualTo(updated);
        await Assert.That(result.Condition).IsEqualTo(original.Condition);
        await Assert.That(result.Include).IsEqualTo(original.Include);
    }
}