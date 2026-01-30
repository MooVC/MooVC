namespace MooVC.Syntax.Attributes.Project.OutputTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithTaskParameterIsCalled
{
    [Fact]
    public void GivenTaskParameterThenReturnsUpdatedInstance()
    {
        // Arrange
        Output original = OutputTestsData.Create();
        var updated = new Identifier("Other");

        // Act
        Output result = original.WithTaskParameter(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.TaskParameter.ShouldBe(updated);
        result.ItemName.ShouldBe(original.ItemName);
        result.PropertyName.ShouldBe(original.PropertyName);
    }
}