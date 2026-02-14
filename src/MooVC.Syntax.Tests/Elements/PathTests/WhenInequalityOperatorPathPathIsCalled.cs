namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenInequalityOperatorPathPathIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Path? left = default;
        Path? right = default;

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
        var right = new Path(PathTestsData.DefaultPath);

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
        var right = new Path(PathTestsData.DefaultPath);

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
        var right = new Path(PathTestsData.DefaultAlternativePath);

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}