namespace MooVC.Syntax.Attributes.Project.OutputTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        Output subject = OutputTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Output subject = OutputTestsData.Create();
        object other = OutputTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}