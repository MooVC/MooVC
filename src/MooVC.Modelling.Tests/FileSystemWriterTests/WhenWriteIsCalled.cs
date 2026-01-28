namespace MooVC.Modelling.FileSystemWriterTests;

using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Options;

public sealed class WhenWriteIsCalled
{
    private const int BufferSize = 128;
    private const string Content = "Hello, MooVC!";
    private const string Extension = "txt";
    private const string Name = "example";
    private const string PathValue = "Models";
    private const string RootPath = "Root";

    [Fact]
    public async Task GivenFilesThenContentIsWritten()
    {
        // Arrange
        File testFile = new(Content, Extension, Name, PathValue);
        IAsyncEnumerable<File> files = CreateFiles(testFile);
        IFileSystem fileSystem = new InMemoryFileSystem(RootPath);
        IOptionsSnapshot<FileSystemWriter.Options> optionsSnapshot = CreateOptionsSnapshot();
        IWriter writer = new FileSystemWriter(fileSystem, optionsSnapshot);
        await using var stream = new MemoryStream();
        string expectedPath = fileSystem.GetFullPath(Path.Combine(RootPath, testFile.FilePath));
        string? expectedDirectory = fileSystem.GetDirectoryName(expectedPath);

        // Act
        await writer.Write(files, stream, CancellationToken.None);

        // Assert
        InMemoryFileSystem inMemoryFileSystem = (InMemoryFileSystem)fileSystem;
        bool isFound = inMemoryFileSystem.TryGetFileContent(expectedPath, out byte[]? fileContent);
        isFound.ShouldBeTrue();
        fileContent.ShouldNotBeNull();
        Encoding.UTF8.GetString(fileContent).ShouldBe(Content);
        expectedDirectory.ShouldNotBeNull();
        inMemoryFileSystem.CreatedDirectories.ShouldContain(expectedDirectory);
    }

    private static IOptionsSnapshot<FileSystemWriter.Options> CreateOptionsSnapshot()
    {
        IOptionsSnapshot<FileSystemWriter.Options> optionsSnapshot = Substitute.For<IOptionsSnapshot<FileSystemWriter.Options>>();
        optionsSnapshot.Value.Returns(new FileSystemWriter.Options(BufferSize));
        return optionsSnapshot;
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

internal sealed class InMemoryFileSystem
    : IFileSystem
{
    private readonly Dictionary<string, byte[]> fileContents = new(StringComparer.Ordinal);
    private readonly string rootPath;

    public InMemoryFileSystem(string rootPath)
    {
        this.rootPath = rootPath;
    }

    public HashSet<string> CreatedDirectories { get; } = new(StringComparer.Ordinal);

    public void CreateDirectory(string path)
    {
        _ = CreatedDirectories.Add(path);
    }

    public Stream CreateFileStream(string path, int bufferSize)
    {
        return new InMemoryFileStream(path, bufferSize, fileContents);
    }

    public string GetCurrentDirectory()
    {
        return rootPath;
    }

    public string? GetDirectoryName(string path)
    {
        return Path.GetDirectoryName(path);
    }

    public string GetFullPath(string path)
    {
        return Path.GetFullPath(path, rootPath);
    }

    public bool TryGetFileContent(string path, out byte[]? fileContent)
    {
        return fileContents.TryGetValue(path, out fileContent);
    }
}

internal sealed class InMemoryFileStream
    : MemoryStream
{
    private readonly string path;
    private readonly Dictionary<string, byte[]> fileContents;

    public InMemoryFileStream(string path, int bufferSize, Dictionary<string, byte[]> fileContents)
        : base(bufferSize)
    {
        this.path = path;
        this.fileContents = fileContents;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            fileContents[path] = ToArray();
        }

        base.Dispose(disposing);
    }
}