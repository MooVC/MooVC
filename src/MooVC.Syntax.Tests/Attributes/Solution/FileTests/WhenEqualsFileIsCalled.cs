namespace MooVC.Syntax.Attributes.Solution.FileTests;

public sealed class WhenEqualsFileIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new File(FileTestsData.DefaultPath);

        // Act
        bool result = subject.Equals(default);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var subject = new File(FileTestsData.DefaultPath);
        var other = new File(FileTestsData.DefaultPath);

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new File(FileTestsData.DefaultPath);
        var other = new File("other.cs");

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}