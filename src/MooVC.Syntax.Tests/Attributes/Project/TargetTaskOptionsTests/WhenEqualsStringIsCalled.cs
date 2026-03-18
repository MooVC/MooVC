namespace MooVC.Syntax.Attributes.Project.TargetTaskOptionsTests;

public sealed class WhenEqualsStringIsCalled
{
    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;

        // Act
        bool result = subject.Equals("WarnAndContinue");

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.ErrorAndContinue;

        // Act
        bool result = subject.Equals("WarnAndContinue");

        // Assert
        result.ShouldBeFalse();
    }
}