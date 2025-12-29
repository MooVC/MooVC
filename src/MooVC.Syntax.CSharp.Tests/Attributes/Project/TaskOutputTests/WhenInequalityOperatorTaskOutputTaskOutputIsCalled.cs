namespace MooVC.Syntax.CSharp.Attributes.Project.TaskOutputTests;

public sealed class WhenInequalityOperatorTaskOutputTaskOutputIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        TaskOutput left = TaskOutputTestsData.Create();
        TaskOutput right = TaskOutputTestsData.Create(itemName: new Identifier("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}