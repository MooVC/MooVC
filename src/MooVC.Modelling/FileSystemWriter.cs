namespace MooVC.Modelling;

using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

internal sealed partial class FileSystemWriter(IFileSystem fileSystem, IOptionsSnapshot<FileSystemWriter.Options> options)
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

    private string ResolveRootPath(Stream stream)
    {
        if (stream is FileStream fileStream)
        {
            string? directoryPath = fileSystem.GetDirectoryName(fileStream.Name);

            if (!string.IsNullOrWhiteSpace(directoryPath))
            {
                return directoryPath;
            }
        }

        return fileSystem.GetCurrentDirectory();
    }

    private async Task Write(File file, string rootPath, CancellationToken cancellationToken)
    {
        string filePath = fileSystem.GetFullPath(Path.Combine(rootPath, file.FilePath));
        string? directoryPath = fileSystem.GetDirectoryName(filePath);

        if (!string.IsNullOrWhiteSpace(directoryPath))
        {
            fileSystem.CreateDirectory(directoryPath);
        }

        byte[] contentBytes = Encoding.UTF8.GetBytes(file.Content);

        await using Stream stream = fileSystem.CreateFileStream(filePath, options.Value.BufferSize);

        await stream
            .WriteAsync(contentBytes, cancellationToken)
            .ConfigureAwait(false);
    }
}