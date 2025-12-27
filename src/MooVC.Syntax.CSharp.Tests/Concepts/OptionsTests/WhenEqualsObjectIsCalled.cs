namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNonOptionsObjectThenReturnsFalse()
    {
        // Arrange
        var subject = new Options();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenOptionsObjectThenReturnsTrue()
    {
        // Arrange
        var subject = new Options();
        object other = new Options();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}