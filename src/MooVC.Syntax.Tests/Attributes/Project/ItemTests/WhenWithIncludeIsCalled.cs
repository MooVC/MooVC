namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithIncludeIsCalled
{
    private const string UpdatedInclude = "UpdatedInclude";

    [Test]
    public async Task GivenIncludeThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = Snippet.From(UpdatedInclude);

        // Act
        Item result = original.WithInclude(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Include).IsEqualTo(updated);
        await Assert.That(result.Condition).IsEqualTo(original.Condition);
        await Assert.That(result.Exclude).IsEqualTo(original.Exclude);
    }
}