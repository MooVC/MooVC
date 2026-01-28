namespace MooVC.Modelling;

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

internal sealed class ZipWriter
    : IWriter
{
    public async Task Write(IAsyncEnumerable<File> files, Stream stream, CancellationToken cancellationToken)
    {
        using var archive = new ZipArchive(stream, ZipArchiveMode.Create, leaveOpen: true);

        await foreach (File file in files.WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            await WriteAsync(archive, file, cancellationToken).ConfigureAwait(false);
        }
    }

    private static string BuildEntryPath(File file)
    {
        var extension = string.IsNullOrWhiteSpace(file.Extension)
            ? string.Empty
            : file.Extension.StartsWith(".", StringComparison.Ordinal)
                ? file.Extension
                : $".{file.Extension}";
        var fileName = string.Concat(file.Name, extension);
        var entryPath = string.IsNullOrWhiteSpace(file.Path)
            ? fileName
            : Path.Combine(file.Path, fileName);

        return entryPath
            .Replace(Path.DirectorySeparatorChar, '/')
            .Replace(Path.AltDirectorySeparatorChar, '/');
    }

    private static async Task WriteAsync(ZipArchive archive, File file, CancellationToken cancellationToken)
    {
        var entryPath = BuildEntryPath(file);
        var entry = archive.CreateEntry(entryPath, CompressionLevel.Optimal);
        var contentBytes = Encoding.UTF8.GetBytes(file.Content);

        await using var entryStream = entry.Open();
        await entryStream.WriteAsync(contentBytes, cancellationToken).ConfigureAwait(false);
    }
}