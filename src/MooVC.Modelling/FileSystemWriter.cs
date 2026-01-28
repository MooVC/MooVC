namespace MooVC.Modelling;

using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

internal sealed class FileSystemWriter
    : IWriter
{
    public async Task Write(IAsyncEnumerable<File> files, Stream stream, CancellationToken cancellationToken)
    {
        string rootPath = ResolveRootPath(stream);

        ConfiguredCancelableAsyncEnumerable<File> enumerable = files
            .WithCancellation(cancellationToken)
            .ConfigureAwait(false);

        await foreach (File file in enumerable)
        {
            await Write(file, rootPath, cancellationToken)
                .ConfigureAwait(false);
        }
    }

    private static string ResolveRootPath(Stream stream)
    {
        if (stream is FileStream fileStream)
        {
            string? directoryPath = Path.GetDirectoryName(fileStream.Name);

            if (!string.IsNullOrWhiteSpace(directoryPath))
            {
                return directoryPath;
            }
        }

        return Directory.GetCurrentDirectory();
    }

    private static async Task Write(File file, string rootPath, CancellationToken cancellationToken)
    {
        string filePath = Path.GetFullPath(Path.Combine(rootPath, file.FilePath));
        string? directoryPath = Path.GetDirectoryName(filePath);

        if (!string.IsNullOrWhiteSpace(directoryPath))
        {
            _ = Directory.CreateDirectory(directoryPath);
        }

        byte[] contentBytes = Encoding.UTF8.GetBytes(file.Content);

        await using var stream = new FileStream(
            filePath,
            FileMode.Create,
            FileAccess.Write,
            FileShare.None,
            bufferSize: 4096,
            useAsync: true);

        await stream
            .WriteAsync(contentBytes, cancellationToken)
            .ConfigureAwait(false);
    }
}