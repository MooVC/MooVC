namespace MooVC.Syntax.Solution.FolderTests.PathTests;

public sealed class WhenEqualityOperatorPathPathIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Folder.Path? left = default;
        Folder.Path? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Folder.Path("/Folder/");
        var right = new Folder.Path("/Other/");

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        const string path = "/Folder/";
        var left = new Folder.Path(path);
        var right = new Folder.Path(path);

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}