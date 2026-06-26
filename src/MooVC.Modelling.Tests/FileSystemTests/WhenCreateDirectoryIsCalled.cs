namespace MooVC.Modelling.FileSystemTests;

public sealed class WhenCreateDirectoryIsCalled
{
    [Test]
    public async Task GivenPathThenDirectoryIsCreated()
    {
        // Arrange
        IFileSystem fileSystem = new FileSystem();
        string directoryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

        try
        {
            // Act
            fileSystem.CreateDirectory(directoryPath);

            // Assert
            _ = await Assert.That(Directory.Exists(directoryPath)).IsTrue();
        }
        finally
        {
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, recursive: true);
            }
        }
    }
}