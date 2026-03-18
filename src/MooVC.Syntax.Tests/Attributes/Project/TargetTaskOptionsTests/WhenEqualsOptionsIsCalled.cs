namespace MooVC.Syntax.Attributes.Project.TargetTaskOptionsTests;

public sealed class WhenEqualsOptionsIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;
        TargetTask.Options? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;
        TargetTask.Options other = TargetTask.Options.WarnAndContinue;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;
        TargetTask.Options other = TargetTask.Options.ErrorAndContinue;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}