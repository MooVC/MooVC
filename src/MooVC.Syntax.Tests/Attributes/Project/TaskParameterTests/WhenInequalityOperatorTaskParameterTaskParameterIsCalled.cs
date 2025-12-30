namespace MooVC.Syntax.Attributes.Project.TaskParameterTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorTaskParameterTaskParameterIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        TaskParameter left = TaskParameterTestsData.Create();
        TaskParameter right = TaskParameterTestsData.Create(name: new Identifier("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}