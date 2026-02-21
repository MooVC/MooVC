namespace MooVC.Modelling;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

/// <summary>
/// Writes modelling files to a zip archive.
/// </summary>
/// <param name="options">The configured writer options.</param>
public sealed partial class ZipWriter(IOptionsSnapshot<ZipWriter.Options> options)
    : IWriter
{
    /// <summary>
    /// Writes the provided files to the target stream as a zip archive.
    /// </summary>
    /// <param name="files">The files to write.</param>
    /// <param name="stream">The target stream.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous write operation.</returns>
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
        return file.FullPath
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