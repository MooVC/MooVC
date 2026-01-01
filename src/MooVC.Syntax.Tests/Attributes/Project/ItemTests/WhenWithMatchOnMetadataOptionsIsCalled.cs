namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithMatchOnMetadataOptionsIsCalled
{
    private const string UpdatedMatchOnMetadataOptions = "UpdatedMatchOnMetadataOptions";

    [Fact]
    public void GivenMatchOnMetadataOptionsThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = Snippet.From(UpdatedMatchOnMetadataOptions);

        // Act
        Item result = original.WithMatchOnMetadataOptions(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.MatchOnMetadataOptions.ShouldBe(updated);
        result.MatchOnMetadata.ShouldBe(original.MatchOnMetadata);
        result.Condition.ShouldBe(original.Condition);
    }
}