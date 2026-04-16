namespace MooVC.Syntax.Solution.FolderTests.PathTests;

public sealed class WhenEqualsPathIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Folder.Path("/Folder/");
        var other = new Folder.Path("/Other/");

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        const string path = "/Folder/";
        var subject = new Folder.Path(path);
        var other = new Folder.Path(path);

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Folder.Path("/Folder/");
        Folder.Path? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}