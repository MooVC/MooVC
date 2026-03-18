namespace MooVC.Syntax.Attributes.Project.TargetTaskOptionsTests;

public sealed class WhenEqualsOptionsIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;
        TargetTask.Options? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;
        TargetTask.Options other = TargetTask.Options.WarnAndContinue;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;
        TargetTask.Options other = TargetTask.Options.ErrorAndContinue;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}