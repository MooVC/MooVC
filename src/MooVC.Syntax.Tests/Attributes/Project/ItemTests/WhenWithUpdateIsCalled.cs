namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithUpdateIsCalled
{
    private const string UpdatedUpdate = "UpdatedUpdate";

    [Fact]
    public void GivenUpdateThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = Snippet.From(UpdatedUpdate);

        // Act
        Item result = original.WithUpdate(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Update.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Include.ShouldBe(original.Include);
    }
}