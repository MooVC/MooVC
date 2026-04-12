namespace MooVC.Modelling.FileSystemTests;

public sealed class WhenGetDirectoryNameIsCalled
{
    [Test]
    public async Task GivenFilePathThenDirectoryPathIsReturned()
    {
        // Arrange
        IFileSystem fileSystem = new FileSystem();
        string directoryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        string filePath = Path.Combine(directoryPath, "content.txt");

        // Act
        string? value = fileSystem.GetDirectoryName(filePath);

        // Assert
        _ = await Assert.That(value).IsEqualTo(directoryPath);
    }
}