namespace MooVC.Syntax.Attributes.Project.TaskOutputTests;

using MooVC.Syntax.Elements;

public sealed class WhenForItemIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        TaskOutput original = TaskOutputTestsData.Create();
        var updated = new Identifier("Other");

        // Act
        TaskOutput result = original.ForItem(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.ItemName.ShouldBe(updated);
        result.PropertyName.ShouldBe(original.PropertyName);
        result.TaskParameter.ShouldBe(original.TaskParameter);
        result.Condition.ShouldBe(original.Condition);
    }
}