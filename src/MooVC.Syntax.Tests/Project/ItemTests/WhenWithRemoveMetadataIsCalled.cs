namespace MooVC.Syntax.Project.ItemTests;

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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.RemoveMetadata).IsEqualTo(updated);
        _ = await Assert.That(result.Remove).IsEqualTo(original.Remove);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
    }
}