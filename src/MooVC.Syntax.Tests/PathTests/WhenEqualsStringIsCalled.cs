namespace MooVC.Syntax.PathTests;

public sealed class WhenEqualsStringIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        string? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        string other = PathTestsData.DefaultPath;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        string other = PathTestsData.DefaultAlternativePath;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}