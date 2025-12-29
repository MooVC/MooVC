namespace MooVC.Syntax.CSharp.Attributes.Project.TargetTaskOptionsTests;

public sealed class WhenInequalityOperatorOptionsOptionsIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.WarnAndContinue;
        TargetTask.Options right = TargetTask.Options.ErrorAndContinue;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}