namespace MooVC.Syntax.Attributes.Solution.FileTests;

public sealed class WhenEqualityOperatorFileStringIsCalled
{
    [Test]
    public async Task GivenSameValueThenReturnsTrue()
    {
        // Arrange
        var left = new File(FileTestsData.DefaultPath);
        string right = FileTestsData.DefaultPath;

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        var left = new File(FileTestsData.DefaultPath);
        const string right = "assets/other.cs";

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsFalse();
    }
}