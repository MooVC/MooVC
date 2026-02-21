namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithRemoveIsCalled
{
    private const string UpdatedRemove = "UpdatedRemove";

    [Fact]
    public void GivenRemoveThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = UpdatedRemove;

        // Act
        Item result = original.WithRemove(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Remove.ShouldBe(updated);
        result.RemoveMetadata.ShouldBe(original.RemoveMetadata);
        result.Include.ShouldBe(original.Include);
    }
}