namespace MooVC.Syntax.Attributes.Project.TargetTaskOptionsTests;

public sealed class WhenEqualityOperatorOptionsStringIsCalled
{
    [Test]
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

    [Test]
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