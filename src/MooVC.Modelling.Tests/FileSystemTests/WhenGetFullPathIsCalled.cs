namespace MooVC.Modelling.FileSystemTests;

public sealed class WhenGetFullPathIsCalled
{
    [Test]
    public async Task GivenRelativePathThenAbsolutePathIsReturned()
    {
        // Arrange
        IFileSystem fileSystem = new FileSystem();
        string relativePath = Path.Combine("root", "leaf");
        string expected = Path.GetFullPath(relativePath);

        // Act
        string fullPath = fileSystem.GetFullPath(relativePath);

        // Assert
        _ = await Assert.That(fullPath).IsEqualTo(expected);
    }
}