namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenInequalityOperatorPathStringIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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