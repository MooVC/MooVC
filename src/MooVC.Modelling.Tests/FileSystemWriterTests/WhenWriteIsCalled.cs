namespace MooVC.Modelling.FileSystemWriterTests;

using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using FileObject = System.IO.File;

public sealed class WhenWriteIsCalled
{
    private const int BufferSize = 128;
    private const string Content = "Hello, MooVC!";
    private const string Extension = "txt";
    private const string Name = "example";
    private const string PathValue = "Models";
    private const string StreamName = "stream";

    [Test]
    public async Task GivenFilesThenContentIsWritten()
    {
        // Arrange
        File testFile = new(Content, Extension, Name, PathValue);
        IAsyncEnumerable<File> files = CreateFiles(testFile);
        var fileSystem = new InMemoryFileSystem();
        IOptionsSnapshot<FileSystemWriter.Options> optionsSnapshot = CreateOptionsSnapshot();
        IWriter writer = new FileSystemWriter(fileSystem, optionsSnapshot);
        await using var stream = new MemoryStream();
        string expectedPath = fileSystem.GetFullPath(Path.Combine(Environment.CurrentDirectory, testFile.FullPath));
        string? expectedDirectory = fileSystem.GetDirectoryName(expectedPath);

        // Act
        await writer.Write(files, stream, CancellationToken.None);

        // Assert
        bool isFound = fileSystem.TryGetFileContent(expectedPath, out byte[]? fileContent);
        _ = await Assert.That(isFound).IsTrue();
        _ = await Assert.That(fileContent).IsNotNull();
        _ = await Assert.That(Encoding.UTF8.GetString(fileContent)).IsEqualTo(Content);
        _ = await Assert.That(expectedDirectory).IsNotNull();
        _ = await Assert.That(fileSystem.CreatedDirectories).Contains(expectedDirectory);
    }

    [Test]
    public async Task GivenFileStreamThenFileStreamDirectoryIsUsedAsRootPath()
    {
        // Arrange
        File testFile = new(Content, Extension, Name, PathValue);
        IAsyncEnumerable<File> files = CreateFiles(testFile);
        var fileSystem = new InMemoryFileSystem();
        IOptionsSnapshot<FileSystemWriter.Options> optionsSnapshot = CreateOptionsSnapshot();
        IWriter writer = new FileSystemWriter(fileSystem, optionsSnapshot);
        string streamPath = Path.Combine(Environment.CurrentDirectory, StreamName);

        try
        {
            await using var stream = new FileStream(streamPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            string expectedPath = fileSystem.GetFullPath(Path.Combine(Environment.CurrentDirectory, testFile.FullPath));

            // Act
            await writer.Write(files, stream, CancellationToken.None);

            // Assert
            bool isFound = fileSystem.TryGetFileContent(expectedPath, out _);
            _ = await Assert.That(isFound).IsTrue();
        }
        finally
        {
            if (FileObject.Exists(streamPath))
            {
                FileObject.Delete(streamPath);
            }
        }
    }

    [Test]
    public async Task GivenFileWithoutPathThenDirectoryIsNotCreated()
    {
        // Arrange
        File testFile = new(Content, Extension, Name, string.Empty);
        IAsyncEnumerable<File> files = CreateFiles(testFile);
        var fileSystem = new InMemoryFileSystem();
        IOptionsSnapshot<FileSystemWriter.Options> optionsSnapshot = CreateOptionsSnapshot();
        IWriter writer = new FileSystemWriter(fileSystem, optionsSnapshot);
        await using var stream = new MemoryStream();

        // Act
        await writer.Write(files, stream, CancellationToken.None);

        // Assert
        _ = await Assert.That(fileSystem.CreatedDirectories).Contains(Environment.CurrentDirectory);
        _ = await Assert.That(fileSystem.CreatedDirectories).HasSingleItem();
    }

    private static IOptionsSnapshot<FileSystemWriter.Options> CreateOptionsSnapshot()
    {
        IOptionsSnapshot<FileSystemWriter.Options> options = Substitute.For<IOptionsSnapshot<FileSystemWriter.Options>>();

        _ = options.Value.Returns(new FileSystemWriter.Options(BufferSize));

        return options;
    }

    private static async IAsyncEnumerable<File> CreateFiles(params File[] files)
    {
        foreach (File file in files)
        {
            yield return file;

            await Task.Yield();
        }
    }
}