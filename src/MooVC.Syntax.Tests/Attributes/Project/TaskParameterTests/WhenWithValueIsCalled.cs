namespace MooVC.Syntax.Attributes.Project.TaskParameterTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithValueIsCalled
{
    private const string UpdatedValue = "UpdatedValue";

    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        TaskParameter original = TaskParameterTestsData.Create();
        var updated = Snippet.From(UpdatedValue);

        // Act
        TaskParameter result = original.WithValue(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Value.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
    }
}