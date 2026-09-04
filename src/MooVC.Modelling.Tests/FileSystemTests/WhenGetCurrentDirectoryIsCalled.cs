namespace MooVC.Modelling.FileSystemTests;

public sealed class WhenGetCurrentDirectoryIsCalled
{
    [Test]
    public async Task GivenInvocationThenCurrentDirectoryIsReturned()
    {
        // Arrange
        IFileSystem fileSystem = new FileSystem();
        string expected = Directory.GetCurrentDirectory();

        // Act
        string currentDirectory = fileSystem.GetCurrentDirectory();

        // Assert
        _ = await Assert.That(currentDirectory).IsEqualTo(expected);
    }
}