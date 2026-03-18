namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithRemoveIsCalled
{
    private const string UpdatedRemove = "UpdatedRemove";

    [Test]
    public async Task GivenRemoveThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = Snippet.From(UpdatedRemove);

        // Act
        Item result = original.WithRemove(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Remove).IsEqualTo(updated);
        await Assert.That(result.RemoveMetadata).IsEqualTo(original.RemoveMetadata);
        await Assert.That(result.Include).IsEqualTo(original.Include);
    }
}