namespace MooVC.Syntax.Attributes.Project.TaskOutputTests;

using MooVC.Syntax.Elements;

public sealed class WhenForPropertyIsCalled
{
    [Fact]
    public void GivenPropertyNameThenReturnsUpdatedInstance()
    {
        // Arrange
        TaskOutput original = TaskOutputTestsData.Create();
        var updated = new Identifier("Other");

        // Act
        TaskOutput result = original.ForProperty(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.PropertyName.ShouldBe(updated);
        result.ItemName.ShouldBe(original.ItemName);
        result.Condition.ShouldBe(original.Condition);
    }
}