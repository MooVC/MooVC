namespace MooVC.Syntax.Solution.FolderTests.PathTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        var subject = new Folder.Path("/Folder/");

        // Act
        bool result = subject.Equals("/Other/");

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Folder.Path("/Folder/");

        // Act
        bool result = subject.Equals(default(object));

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenPathWithSameValueThenReturnsTrue()
    {
        // Arrange
        const string path = "/Folder/";
        var subject = new Folder.Path(path);
        object other = new Folder.Path(path);

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}