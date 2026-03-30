namespace MooVC.Syntax.PathTests;

public sealed class WhenInequalityOperatorPathStringIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Path(PathTestsData.DefaultPath);
        string right = PathTestsData.DefaultAlternativePath;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Path(PathTestsData.DefaultPath);
        string right = PathTestsData.DefaultPath;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightNullThenReturnsFalse()
    {
        // Arrange
        Path? left = default;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Path? left = default;
        string right = PathTestsData.DefaultPath;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}