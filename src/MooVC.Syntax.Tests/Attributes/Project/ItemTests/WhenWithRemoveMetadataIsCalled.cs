namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithRemoveMetadataIsCalled
{
    private const string UpdatedRemoveMetadata = "UpdatedRemoveMetadata";

    [Test]
    public async Task GivenRemoveMetadataThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = Snippet.From(UpdatedRemoveMetadata);

        // Act
        Item result = original.WithRemoveMetadata(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.RemoveMetadata).IsEqualTo(updated);
        await Assert.That(result.Remove).IsEqualTo(original.Remove);
        await Assert.That(result.Condition).IsEqualTo(original.Condition);
    }
}