namespace MooVC.Syntax.Attributes.Project.TargetTaskOptionsTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask.Options subject = TargetTask.Options.WarnAndContinue;
        object other = TargetTask.Options.WarnAndContinue;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}