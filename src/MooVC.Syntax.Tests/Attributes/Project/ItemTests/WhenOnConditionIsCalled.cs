namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenOnConditionIsCalled
{
    private const string UpdatedCondition = "UpdatedCondition";

    [Fact]
    public void GivenConditionThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create(metadata: ItemTestsData.CreateMetadata());
        var updated = UpdatedCondition;

        // Act
        Item result = original.OnCondition(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Condition.ShouldBe(updated);
        result.Exclude.ShouldBe(original.Exclude);
        result.Include.ShouldBe(original.Include);
    }
}