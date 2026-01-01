namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithMatchOnMetadataIsCalled
{
    private const string UpdatedMatchOnMetadata = "UpdatedMatchOnMetadata";

    [Fact]
    public void GivenMatchOnMetadataThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = Snippet.From(UpdatedMatchOnMetadata);

        // Act
        Item result = original.WithMatchOnMetadata(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.MatchOnMetadata.ShouldBe(updated);
        result.MatchOnMetadataOptions.ShouldBe(original.MatchOnMetadataOptions);
        result.Condition.ShouldBe(original.Condition);
    }
}