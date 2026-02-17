namespace MooVC.Syntax.Attributes.Project.OutputTests;

using MooVC.Syntax.Elements;

public sealed class WhenForItemIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Output original = OutputTestsData.Create();
        var updated = new Name("Other");

        // Act
        Output result = original.ForItem(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.ItemName.ShouldBe(updated);
        result.PropertyName.ShouldBe(original.PropertyName);
        result.TaskParameter.ShouldBe(original.TaskParameter);
        result.Condition.ShouldBe(original.Condition);
    }
}