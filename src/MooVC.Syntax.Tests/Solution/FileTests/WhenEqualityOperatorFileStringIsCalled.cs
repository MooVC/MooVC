namespace MooVC.Syntax.Solution.FileTests;

public sealed class WhenEqualityOperatorFileStringIsCalled
{
    [Test]
    public async Task GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        var left = new File(FileTestsData.DefaultPath);
        const string right = "assets/other.cs";

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameValueThenReturnsTrue()
    {
        // Arrange
        var left = new File(FileTestsData.DefaultPath);
        string right = FileTestsData.DefaultPath;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}