namespace MooVC.Syntax.Attributes.Solution.FileTests;

public sealed class WhenEqualsFileIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new File(FileTestsData.DefaultPath);

        // Act
        bool result = subject.Equals(default(File));

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var subject = new File(FileTestsData.DefaultPath);
        var other = new File(FileTestsData.DefaultPath);

        // Act
        bool result = subject.Equals(other);

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new File(FileTestsData.DefaultPath);
        var other = new File("other.cs");

        // Act
        bool result = subject.Equals(other);

        // Assert
        await Assert.That(result).IsFalse();
    }
}