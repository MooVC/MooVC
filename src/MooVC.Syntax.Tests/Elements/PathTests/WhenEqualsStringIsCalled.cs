namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenEqualsStringIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
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