namespace MooVC.Syntax.Attributes.Project.TaskOutputTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithTaskParameterIsCalled
{
    [Fact]
    public void GivenTaskParameterThenReturnsUpdatedInstance()
    {
        // Arrange
        TaskOutput original = TaskOutputTestsData.Create();
        var updated = new Identifier("Other");

        // Act
        TaskOutput result = original.WithTaskParameter(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.TaskParameter.ShouldBe(updated);
        result.ItemName.ShouldBe(original.ItemName);
        result.PropertyName.ShouldBe(original.PropertyName);
    }
}