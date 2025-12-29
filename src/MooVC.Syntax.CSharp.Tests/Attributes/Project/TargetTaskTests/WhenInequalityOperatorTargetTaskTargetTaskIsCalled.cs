namespace MooVC.Syntax.CSharp.Attributes.Project.TargetTaskTests;

using MooVC.Syntax.CSharp.Elements;

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