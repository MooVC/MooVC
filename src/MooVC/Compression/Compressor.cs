namespace MooVC.Compression;

using MooVC.IO;

/// <summary>
/// Represents an abstract compressor that provides methods for compressing and decompressing streams of data asynchronously.
/// </summary>
public abstract class Compressor
    : ICompressor
{
    /// <summary>
    /// Compresses the specified data asynchronously.
    /// </summary>
    /// <param name="data">The data to compress.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> to use for cancelling the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}" /> that represents the asynchronous operation.
    /// The task result contains the compressed data as a sequence of bytes.
    /// </returns>
    public async Task<IEnumerable<byte>> CompressAsync(IEnumerable<byte> data, CancellationToken cancellationToken)
    {
        using var source = new MemoryStream(data.ToArray());

        using Stream compressed = await CompressAsync(source, cancellationToken)
            .ConfigureAwait(false);

        return compressed.GetBytes();
    }

    /// <summary>
    /// When implemented in a derived class, compresses the specified stream asynchronously.
    /// </summary>
    /// <param name="source">The stream to compress.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> to use for cancelling the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}" /> that represents the asynchronous operation.
    /// The task result contains the compressed stream.
    /// </returns>
    public abstract Task<Stream> CompressAsync(Stream source, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously decompresses a given sequence of bytes.
    /// </summary>
    /// <param name="data">The sequence of bytes to decompress.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}" /> that represents the asynchronous decompression operation.
    /// The task result contains the decompressed data as a sequence of bytes.
    /// </returns>
    public async Task<IEnumerable<byte>> DecompressAsync(IEnumerable<byte> data, CancellationToken cancellationToken)
    {
        using var source = new MemoryStream(data.ToArray());

        using Stream decompressed = await DecompressAsync(source, cancellationToken)
            .ConfigureAwait(false);

        return decompressed.GetBytes();
    }

    /// <summary>
    /// Asynchronously decompresses a given stream of data.
    /// </summary>
    /// <param name="source">The stream of data to decompress.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}" /> that represents the asynchronous decompression operation.
    /// The task result contains the decompressed data as a stream.
    /// </returns>
    public abstract Task<Stream> DecompressAsync(Stream source, CancellationToken cancellationToken);
}