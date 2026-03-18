namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenEqualityOperatorPathStringIsCalled
{
    [Test]
    public void GivenLeftNullRightNullThenReturnsTrue()
    {
        // Arrange
        Path? left = default;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Path? left = default;
        string right = PathTestsData.DefaultPath;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Path(PathTestsData.DefaultPath);
        string right = PathTestsData.DefaultPath;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Path(PathTestsData.DefaultPath);
        string right = PathTestsData.DefaultAlternativePath;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}