namespace MooVC.Syntax.Attributes.Project.TaskOutputTests;

using MooVC.Syntax.Elements;

public sealed class WhenOnConditionIsCalled
{
    private const string UpdatedCondition = "UpdatedCondition";

    [Fact]
    public void GivenConditionThenReturnsUpdatedInstance()
    {
        // Arrange
        TaskOutput original = TaskOutputTestsData.Create();
        var updated = Snippet.From(UpdatedCondition);

        // Act
        TaskOutput result = original.OnCondition(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Condition.ShouldBe(updated);
        result.ItemName.ShouldBe(original.ItemName);
        result.PropertyName.ShouldBe(original.PropertyName);
    }
}