namespace MooVC.Modelling
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// Writes modelling files to the local file system.
    /// </summary>
    public sealed partial class FileSystemWriter
        : IWriter
    {
        private readonly IFileSystem _fileSystem;
        private readonly IOptionsSnapshot<FileSystemWriter.Options> _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemWriter"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system abstraction to use.</param>
        /// <param name="options">The configured writer options.</param>
        public FileSystemWriter(IFileSystem fileSystem, IOptionsSnapshot<FileSystemWriter.Options> options)
        {
            _fileSystem = fileSystem;
            _options = options;
        }

        /// <summary>
        /// Writes the provided files to the target stream location.
        /// </summary>
        public async Task Write(IAsyncEnumerable<File> files, Stream stream, CancellationToken cancellationToken)
        {
            string rootPath = ResolveRootPath(stream);
            IAsyncEnumerator<File> enumerator = files.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    await Write(enumerator.Current, rootPath, cancellationToken)
                        .ConfigureAwait(false);
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
        }

        private string ResolveRootPath(Stream stream)
        {
            FileStream fileStream = stream as FileStream;

            if (fileStream != null)
            {
                string directoryPath = _fileSystem.GetDirectoryName(fileStream.Name);

                if (!string.IsNullOrWhiteSpace(directoryPath))
                {
                    return directoryPath;
                }
            }

            return _fileSystem.GetCurrentDirectory();
        }

        private async Task Write(File file, string rootPath, CancellationToken cancellationToken)
        {
            string filePath = _fileSystem.GetFullPath(Path.Combine(rootPath, file.FullPath));
            string directoryPath = _fileSystem.GetDirectoryName(filePath);

            if (!string.IsNullOrWhiteSpace(directoryPath))
            {
                _fileSystem.CreateDirectory(directoryPath);
            }

            byte[] contentBytes = Encoding.UTF8.GetBytes(file.Content);

            using (Stream stream = _fileSystem.CreateFileStream(filePath, _options.Value.BufferSize))
            {
                await stream.WriteAsync(contentBytes, 0, contentBytes.Length, cancellationToken)
                    .ConfigureAwait(false);
            }
        }
    }
}
