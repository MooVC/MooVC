namespace MooVC.Syntax.Attributes.Project.TargetTaskOptionsTests;

public sealed class WhenEqualityOperatorOptionsOptionsIsCalled
{
    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.WarnAndContinue;
        TargetTask.Options right = TargetTask.Options.WarnAndContinue;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.WarnAndContinue;
        TargetTask.Options right = TargetTask.Options.ErrorAndContinue;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}