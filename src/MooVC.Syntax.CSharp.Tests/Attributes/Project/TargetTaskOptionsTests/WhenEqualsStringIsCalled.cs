namespace MooVC.Syntax.CSharp.Attributes.Project.TargetTaskOptionsTests;

public sealed class WhenEqualsStringIsCalled
{
    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;

        // Act
        bool result = subject.Equals("WarnAndContinue");

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
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