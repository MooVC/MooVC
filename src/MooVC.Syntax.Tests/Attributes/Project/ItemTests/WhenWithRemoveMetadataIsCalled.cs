namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithRemoveMetadataIsCalled
{
    private const string UpdatedRemoveMetadata = "UpdatedRemoveMetadata";

    [Fact]
    public void GivenRemoveMetadataThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = UpdatedRemoveMetadata;

        // Act
        Item result = original.WithRemoveMetadata(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.RemoveMetadata.ShouldBe(updated);
        result.Remove.ShouldBe(original.Remove);
        result.Condition.ShouldBe(original.Condition);
    }
}