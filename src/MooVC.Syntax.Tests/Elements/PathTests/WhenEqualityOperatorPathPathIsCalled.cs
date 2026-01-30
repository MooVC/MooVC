namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenEqualityOperatorPathPathIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Path? left = default;
        Path? right = default;

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
        var right = new Path(PathTestsData.DefaultPath);

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
        var right = new Path(PathTestsData.DefaultPath);

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
        var right = new Path(PathTestsData.DefaultAlternativePath);

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}