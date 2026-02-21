namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithExcludeIsCalled
{
    private const string UpdatedExclude = "UpdatedExclude";

    [Fact]
    public void GivenExcludeThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = UpdatedExclude;

        // Act
        Item result = original.WithExclude(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Exclude.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Include.ShouldBe(original.Include);
    }
}