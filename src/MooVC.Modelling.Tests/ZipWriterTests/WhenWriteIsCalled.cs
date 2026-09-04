namespace MooVC.Modelling.ZipWriterTests;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO.Compression;
using System.Text;
using Microsoft.Extensions.Options;

public sealed class WhenWriteIsCalled
{
    private const string Content = "Hello, MooVC!";
    private const string Extension = "txt";
    private const string NestedPathValue = "Models\\Nested";
    private const string Name = "example";
    private const string PathValue = "Models";

    [Test]
    [SuppressMessage("Major Code Smell", "S6966:Awaitable method should be used", Justification = "Feature is not available in all supported versions.")]
    public async Task GivenFilesThenArchiveContainsEntry()
    {
        // Arrange
        File testFile = new(Content, Extension, Name, PathValue);
        IAsyncEnumerable<File> files = CreateFiles(testFile);
        IOptionsSnapshot<ZipWriter.Options> optionsSnapshot = CreateOptionsSnapshot();
        IWriter writer = new ZipWriter(optionsSnapshot);

        await using var stream = new MemoryStream();

        string expectedEntryPath = testFile.FullPath
            .Replace(Path.DirectorySeparatorChar, '/')
            .Replace(Path.AltDirectorySeparatorChar, '/');

        // Act
        await writer.Write(files, stream, CancellationToken.None);

        // Assert
        stream.Position = 0;
        using var archive = new ZipArchive(stream, ZipArchiveMode.Read, leaveOpen: true);
        ZipArchiveEntry entry = archive.Entries.Single();
        _ = await Assert.That(entry.FullName).IsEqualTo(expectedEntryPath);
        await using Stream entryStream = entry.Open();
        using var reader = new StreamReader(entryStream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, leaveOpen: false);
        string entryContent = await reader.ReadToEndAsync();
        _ = await Assert.That(entryContent).IsEqualTo(Content);
    }

    [Test]
    [SuppressMessage("Major Code Smell", "S6966:Awaitable method should be used", Justification = "Feature is not available in all supported versions.")]
    public async Task GivenMultipleFilesThenArchiveContainsAllEntries()
    {
        // Arrange
        File first = new(Content, Extension, Name, PathValue);
        File second = new(string.Concat(Content, "!"), Extension, "example2", NestedPathValue);
        IAsyncEnumerable<File> files = CreateFiles(first, second);
        IOptionsSnapshot<ZipWriter.Options> optionsSnapshot = CreateOptionsSnapshot();
        IWriter writer = new ZipWriter(optionsSnapshot);

        await using var stream = new MemoryStream();

        // Act
        await writer.Write(files, stream, CancellationToken.None);

        // Assert
        stream.Position = 0;
        using var archive = new ZipArchive(stream, ZipArchiveMode.Read, leaveOpen: true);
        _ = await Assert.That(archive.Entries.Count).IsEqualTo(2);
        _ = await Assert.That(archive.Entries.Select(entry => entry.FullName)).Contains("Models/example.txt");
        _ = await Assert.That(archive.Entries.Select(entry => entry.FullName)).Contains("Models/Nested/example2.txt");
    }

    private static IOptionsSnapshot<ZipWriter.Options> CreateOptionsSnapshot()
    {
        IOptionsSnapshot<ZipWriter.Options> options = Substitute.For<IOptionsSnapshot<ZipWriter.Options>>();

        _ = options.Value.Returns(new ZipWriter.Options(CompressionLevel.NoCompression));

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