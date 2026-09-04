namespace MooVC.Syntax.Project.ItemTests;

public sealed class WhenWithMatchOnMetadataOptionsIsCalled
{
    private const string UpdatedMatchOnMetadataOptions = "UpdatedMatchOnMetadataOptions";

    [Test]
    public async Task GivenMatchOnMetadataOptionsThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = Snippet.From(UpdatedMatchOnMetadataOptions);

        // Act
        Item result = original.WithMatchOnMetadataOptions(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.MatchOnMetadataOptions).IsEqualTo(updated);
        _ = await Assert.That(result.MatchOnMetadata).IsEqualTo(original.MatchOnMetadata);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
    }
}