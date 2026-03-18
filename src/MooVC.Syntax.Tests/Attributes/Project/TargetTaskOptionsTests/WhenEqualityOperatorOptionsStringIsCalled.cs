namespace MooVC.Syntax.Attributes.Project.TargetTaskOptionsTests;

public sealed class WhenEqualityOperatorOptionsStringIsCalled
{
    [Test]
    public async Task GivenMatchingValueThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.WarnAndContinue;
        const string Right = "WarnAndContinue";

        // Act
        bool result = left == Right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.ErrorAndContinue;
        const string Right = "WarnAndContinue";

        // Act
        bool result = left == Right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}