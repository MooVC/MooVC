namespace MooVC.Modelling.FileSystemTests;

using System.Text;
using FileObject = System.IO.File;

public sealed class WhenCreateFileStreamIsCalled
{
    private const int BufferSize = 4096;
    private const string Content = "content";

    [Test]
    public async Task GivenFilePathThenWritableFileStreamIsReturned()
    {
        // Arrange
        IFileSystem fileSystem = new FileSystem();
        string filePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        byte[] bytes = Encoding.UTF8.GetBytes(Content);

        try
        {
            // Act
            await using (Stream stream = fileSystem.CreateFileStream(filePath, BufferSize))
            {
                await stream.WriteAsync(bytes, CancellationToken.None);
            }

            string value = await FileObject.ReadAllTextAsync(filePath);

            // Assert
            _ = await Assert.That(value).IsEqualTo(Content);
        }
        finally
        {
            if (FileObject.Exists(filePath))
            {
                FileObject.Delete(filePath);
            }
        }
    }
}