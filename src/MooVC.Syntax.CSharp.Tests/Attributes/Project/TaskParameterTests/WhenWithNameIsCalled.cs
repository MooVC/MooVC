namespace MooVC.Syntax.CSharp.Attributes.Project.TaskParameterTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenWithNameIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        TaskParameter original = TaskParameterTestsData.Create();
        Identifier updated = new Identifier("Other");

        // Act
        TaskParameter result = original.WithName(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Value.ShouldBe(original.Value);
    }
}