namespace MooVC.Syntax.Attributes.Solution.FileTests;

public sealed class WhenEqualsFileIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new File(FileTestsData.DefaultPath);

        // Act
        bool result = subject.Equals(default(File));

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
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

    [Test]
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