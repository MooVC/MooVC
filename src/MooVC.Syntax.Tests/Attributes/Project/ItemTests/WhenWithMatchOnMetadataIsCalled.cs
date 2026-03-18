namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithMatchOnMetadataIsCalled
{
    private const string UpdatedMatchOnMetadata = "UpdatedMatchOnMetadata";

    [Test]
    public async Task GivenMatchOnMetadataThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = Snippet.From(UpdatedMatchOnMetadata);

        // Act
        Item result = original.WithMatchOnMetadata(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.MatchOnMetadata).IsEqualTo(updated);
        _ = await Assert.That(result.MatchOnMetadataOptions).IsEqualTo(original.MatchOnMetadataOptions);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
    }
}