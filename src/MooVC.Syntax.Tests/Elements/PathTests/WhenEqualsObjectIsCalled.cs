namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);

        // Act
        bool result = subject.Equals(default(object));

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        var other = new object();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        var other = new Path(PathTestsData.DefaultPath);

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        var other = new Path(PathTestsData.DefaultAlternativePath);

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}