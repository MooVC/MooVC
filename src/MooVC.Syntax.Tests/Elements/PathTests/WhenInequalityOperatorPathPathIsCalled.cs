namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenInequalityOperatorPathPathIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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