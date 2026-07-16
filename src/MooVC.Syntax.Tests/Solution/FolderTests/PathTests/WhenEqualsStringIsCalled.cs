namespace MooVC.Syntax.Solution.FolderTests.PathTests;

public sealed class WhenEqualsStringIsCalled
{
    [Test]
    public async Task GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        var subject = new Folder.Path("/Folder/");

        // Act
        bool result = subject.Equals("/Other/");

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValueThenReturnsTrue()
    {
        // Arrange
        const string path = "/Folder/";
        var subject = new Folder.Path(path);

        // Act
        bool result = subject.Equals(path);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Folder.Path("/Folder/");

        // Act
        bool result = subject.Equals(default(string));

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}