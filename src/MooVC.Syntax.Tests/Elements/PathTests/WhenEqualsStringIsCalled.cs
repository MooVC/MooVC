namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenEqualsStringIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        string? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        string other = PathTestsData.DefaultPath;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        string other = PathTestsData.DefaultAlternativePath;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}