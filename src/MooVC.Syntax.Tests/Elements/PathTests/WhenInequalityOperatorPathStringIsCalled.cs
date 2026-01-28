namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenInequalityOperatorPathStringIsCalled
{
    [Fact]
    public void GivenLeftNullRightNullThenReturnsFalse()
    {
        // Arrange
        Path? left = default;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Path? left = default;
        string right = PathTestsData.DefaultPath;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Path(PathTestsData.DefaultPath);
        string right = PathTestsData.DefaultPath;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Path(PathTestsData.DefaultPath);
        string right = PathTestsData.DefaultAlternativePath;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}