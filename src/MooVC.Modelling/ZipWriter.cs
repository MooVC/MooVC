namespace MooVC.Modelling;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

public sealed partial class ZipWriter(IOptionsSnapshot<ZipWriter.Options> options)
    : IWriter
{
    public async Task Write(IAsyncEnumerable<File> files, Stream stream, CancellationToken cancellationToken)
    {
        using var archive = new ZipArchive(stream, ZipArchiveMode.Create, leaveOpen: true);

        ConfiguredCancelableAsyncEnumerable<File> enumerable = files
            .WithCancellation(cancellationToken)
            .ConfigureAwait(false);

        await foreach (File file in enumerable)
        {
            await Write(archive, file, cancellationToken)
                .ConfigureAwait(false);
        }
    }

    private static string BuildEntryPath(File file)
    {
        return file.FilePath
            .Replace(Path.DirectorySeparatorChar, '/')
            .Replace(Path.AltDirectorySeparatorChar, '/');
    }

    [SuppressMessage("Major Code Smell", "S6966:Awaitable method should be used", Justification = "Option not available in all supported versions.")]
    private async Task Write(ZipArchive archive, File file, CancellationToken cancellationToken)
    {
        string entryPath = BuildEntryPath(file);
        ZipArchiveEntry entry = archive.CreateEntry(entryPath, options.Value.Compression);
        byte[] contentBytes = Encoding.UTF8.GetBytes(file.Content);

        await using Stream stream = entry.Open();

        await stream
            .WriteAsync(contentBytes, cancellationToken)
            .ConfigureAwait(false);
    }
}