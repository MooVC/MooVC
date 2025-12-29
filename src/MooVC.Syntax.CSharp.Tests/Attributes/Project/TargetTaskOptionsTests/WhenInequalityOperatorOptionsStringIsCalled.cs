namespace MooVC.Syntax.CSharp.Attributes.Project.TargetTaskOptionsTests;

public sealed class WhenInequalityOperatorOptionsStringIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.ErrorAndContinue;
        const string Right = "WarnAndContinue";

        // Act
        bool result = left != Right;

        // Assert
        result.ShouldBeTrue();
    }
}