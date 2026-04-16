namespace MooVC.Modelling
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// Writes modelling files to a zip archive.
    /// </summary>
    public sealed partial class ZipWriter
        : IWriter
    {
        private readonly IOptionsSnapshot<ZipWriter.Options> _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZipWriter"/> class.
        /// </summary>
        public ZipWriter(IOptionsSnapshot<ZipWriter.Options> options)
        {
            _options = options;
        }

        /// <summary>
        /// Writes the provided files to the target stream as a zip archive.
        /// </summary>
        public async Task Write(IAsyncEnumerable<File> files, Stream stream, CancellationToken cancellationToken)
        {
            using (var archive = new ZipArchive(stream, ZipArchiveMode.Create, true))
            {
                IAsyncEnumerator<File> enumerator = files.GetAsyncEnumerator(cancellationToken);

                try
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        await Write(archive, enumerator.Current, cancellationToken)
                            .ConfigureAwait(false);
                    }
                }
                finally
                {
                    await enumerator.DisposeAsync().ConfigureAwait(false);
                }
            }
        }

        private static string BuildEntryPath(File file)
        {
            return file.FullPath.Replace('\\', '/');
        }

        [SuppressMessage("Major Code Smell", "S6966:Awaitable method should be used", Justification = "Option not available in all supported versions.")]
        private async Task Write(ZipArchive archive, File file, CancellationToken cancellationToken)
        {
            string entryPath = BuildEntryPath(file);
            ZipArchiveEntry entry = archive.CreateEntry(entryPath, _options.Value.Compression);
            byte[] contentBytes = Encoding.UTF8.GetBytes(file.Content);

            using (Stream stream = entry.Open())
            {
                await stream.WriteAsync(contentBytes, 0, contentBytes.Length, cancellationToken)
                    .ConfigureAwait(false);
            }
        }
    }
}
