namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithIncludeIsCalled
{
    private const string UpdatedInclude = "UpdatedInclude";

    [Fact]
    public void GivenIncludeThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = Snippet.From(UpdatedInclude);

        // Act
        Item result = original.WithInclude(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Include.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Exclude.ShouldBe(original.Exclude);
    }
}