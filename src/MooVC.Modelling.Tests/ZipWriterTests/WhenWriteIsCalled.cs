namespace MooVC.Modelling.ZipWriterTests;

using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using Microsoft.Extensions.Options;

public sealed class WhenWriteIsCalled
{
    private const string Content = "Hello, MooVC!";
    private const string Extension = "txt";
    private const string Name = "example";
    private const string PathValue = "Models";

    [Fact]
    public async Task GivenFilesThenArchiveContainsEntry()
    {
        // Arrange
        File testFile = new(Content, Extension, Name, PathValue);
        IAsyncEnumerable<File> files = CreateFiles(testFile);
        IOptionsSnapshot<ZipWriter.Options> optionsSnapshot = CreateOptionsSnapshot();
        IWriter writer = new ZipWriter(optionsSnapshot);
        await using var stream = new MemoryStream();
        string expectedEntryPath = testFile.FilePath
            .Replace(Path.DirectorySeparatorChar, '/')
            .Replace(Path.AltDirectorySeparatorChar, '/');

        // Act
        await writer.Write(files, stream, CancellationToken.None);

        // Assert
        stream.Position = 0;
        using var archive = new ZipArchive(stream, ZipArchiveMode.Read, leaveOpen: true);
        ZipArchiveEntry entry = archive.Entries.Single();
        entry.FullName.ShouldBe(expectedEntryPath);
        await using Stream entryStream = entry.Open();
        using var reader = new StreamReader(entryStream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, leaveOpen: false);
        string entryContent = await reader.ReadToEndAsync();
        entryContent.ShouldBe(Content);
    }

    private static IOptionsSnapshot<ZipWriter.Options> CreateOptionsSnapshot()
    {
        IOptionsSnapshot<ZipWriter.Options> optionsSnapshot = Substitute.For<IOptionsSnapshot<ZipWriter.Options>>();
        optionsSnapshot.Value.Returns(new ZipWriter.Options(CompressionLevel.NoCompression));
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