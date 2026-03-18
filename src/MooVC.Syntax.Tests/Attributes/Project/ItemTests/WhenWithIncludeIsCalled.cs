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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Include).IsEqualTo(updated);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
        _ = await Assert.That(result.Exclude).IsEqualTo(original.Exclude);
    }
}