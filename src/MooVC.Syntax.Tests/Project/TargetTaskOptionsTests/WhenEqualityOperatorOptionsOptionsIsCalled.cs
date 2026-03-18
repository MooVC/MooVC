namespace MooVC.Syntax.Project.TargetTaskOptionsTests;

public sealed class WhenEqualityOperatorOptionsOptionsIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.WarnAndContinue;
        TargetTask.Options right = TargetTask.Options.WarnAndContinue;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TargetTask.Options left = TargetTask.Options.WarnAndContinue;
        TargetTask.Options right = TargetTask.Options.ErrorAndContinue;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}