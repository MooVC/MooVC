namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.MatchOnMetadataOptions).IsEqualTo(updated);
        await Assert.That(result.MatchOnMetadata).IsEqualTo(original.MatchOnMetadata);
        await Assert.That(result.Condition).IsEqualTo(original.Condition);
    }
}