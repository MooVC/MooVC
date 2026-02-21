namespace MooVC.Syntax.Concepts.ResourceTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Resource subject = ResourceTestsData.Create();

        // Act
        bool result = subject.Equals(null);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        Resource subject = ResourceTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Resource subject = ResourceTestsData.Create();
        object other = ResourceTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}