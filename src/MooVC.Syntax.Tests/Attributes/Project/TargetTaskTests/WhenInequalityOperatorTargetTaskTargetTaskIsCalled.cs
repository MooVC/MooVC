namespace MooVC.Syntax.Attributes.Project.TargetTaskTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorTargetTaskTargetTaskIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask left = TargetTaskTestsData.Create();
        TargetTask right = TargetTaskTestsData.Create(name: new Identifier("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}