namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenEqualityOperatorPathStringIsCalled
{
    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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