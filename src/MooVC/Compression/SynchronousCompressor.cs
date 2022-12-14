namespace MooVC.Compression;

using System.IO;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Abstract base class for implementing a synchronous data compressor.
/// </summary>
public abstract class SynchronousCompressor
    : Compressor
{
    /// <summary>
    /// Asynchronously compresses a given stream of data.
    /// </summary>
    /// <param name="source">The stream of data to compress.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous compression operation. The task result contains the
    /// compressed data as a stream.
    /// </returns>
    public override Task<Stream> CompressAsync(Stream source, CancellationToken? cancellationToken = default)
    {
        return Task.FromResult(PerformCompress(source));
    }

    /// <summary>
    /// Asynchronously decompresses a given stream of data.
    /// </summary>
    /// <param name="source">The stream of data to decompress.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous decompression operation. The task result contains the
    /// decompressed data as a stream.
    /// </returns>
    public override Task<Stream> DecompressAsync(Stream source, CancellationToken? cancellationToken = default)
    {
        return Task.FromResult(PerformDecompress(source));
    }

    /// <summary>
    /// When implemented in a derived class, performs the compression of the given stream and returns the result as a new stream.
    /// </summary>
    /// <param name="source">The stream to compress.</param>
    /// <returns>The compressed stream.</returns>
    protected abstract Stream PerformCompress(Stream source);

    /// <summary>
    /// When implemented in a derived class, performs the decompression of the given stream and returns the result as a new stream.
    /// </summary>
    /// <param name="source">The stream to decompress.</param>
    /// <returns>The decompressed stream.</returns>
    protected abstract Stream PerformDecompress(Stream source);
}