namespace MooVC.Syntax.Attributes.Project.OutputTests;

using MooVC.Syntax.Elements;

public sealed class WhenOnConditionIsCalled
{
    private const string UpdatedCondition = "UpdatedCondition";

    [Fact]
    public void GivenConditionThenReturnsUpdatedInstance()
    {
        // Arrange
        Output original = OutputTestsData.Create();
        var updated = Snippet.From(UpdatedCondition);

        // Act
        Output result = original.OnCondition(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Condition.ShouldBe(updated);
        result.ItemName.ShouldBe(original.ItemName);
        result.PropertyName.ShouldBe(original.PropertyName);
    }
}