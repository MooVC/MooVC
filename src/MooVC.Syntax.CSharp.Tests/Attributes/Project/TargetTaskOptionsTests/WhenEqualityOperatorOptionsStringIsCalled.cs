namespace MooVC.Syntax.CSharp.Attributes.Project.TargetTaskOptionsTests;

public sealed class WhenEqualityOperatorOptionsStringIsCalled
{
    [Fact]
    public void GivenMatchingValueThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.WarnAndContinue;
        const string Right = "WarnAndContinue";

        // Act
        bool result = left == Right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.ErrorAndContinue;
        const string Right = "WarnAndContinue";

        // Act
        bool result = left == Right;

        // Assert
        result.ShouldBeFalse();
    }
}