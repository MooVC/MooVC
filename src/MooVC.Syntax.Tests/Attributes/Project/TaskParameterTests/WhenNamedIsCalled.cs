namespace MooVC.Syntax.Attributes.Project.TaskParameterTests;

using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        TaskParameter original = TaskParameterTestsData.Create();
        var updated = new Identifier("Other");

        // Act
        TaskParameter result = original.Named(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Value.ShouldBe(original.Value);
    }
}