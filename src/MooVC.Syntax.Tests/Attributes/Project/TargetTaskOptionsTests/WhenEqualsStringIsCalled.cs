namespace MooVC.Syntax.Attributes.Project.TargetTaskOptionsTests;

public sealed class WhenEqualsStringIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;

        // Act
        bool result = subject.Equals("WarnAndContinue");

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.ErrorAndContinue;

        // Act
        bool result = subject.Equals("WarnAndContinue");

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}