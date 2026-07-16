namespace MooVC.Syntax.Solution.FolderTests.PathTests;

public sealed class WhenEqualityOperatorPathStringIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Folder.Path("/Folder/");
        const string other = "/Other/";

        // Act
        bool result = subject == other;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        const string path = "/Folder/";
        var subject = new Folder.Path(path);

        // Act
        bool result = subject == path;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}