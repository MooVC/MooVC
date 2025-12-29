namespace MooVC.Syntax.CSharp.Attributes.Project.TaskOutputTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenWithItemNameIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        TaskOutput original = TaskOutputTestsData.Create();
        Identifier updated = new Identifier("Other");

        // Act
        TaskOutput result = original.WithItemName(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.ItemName.ShouldBe(updated);
        result.PropertyName.ShouldBe(original.PropertyName);
        result.TaskParameter.ShouldBe(original.TaskParameter);
        result.Condition.ShouldBe(original.Condition);
    }
}