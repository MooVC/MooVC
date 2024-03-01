namespace MooVC.Compression;

/// <summary>
/// Represents a compressor that can compress and decompress data.
/// </summary>
public interface ICompressor
{
    /// <summary>
    /// Compresses a sequence of bytes asynchronously.
    /// </summary>
    /// <param name="data">The sequence of bytes to compress.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}" /> that represents the asynchronous operation.
    /// The task result contains the compressed data as a sequence of bytes.
    /// </returns>
    Task<IEnumerable<byte>> CompressAsync(IEnumerable<byte> data, CancellationToken cancellationToken);

    /// <summary>
    /// Compresses a stream asynchronously.
    /// </summary>
    /// <param name="source">The stream to compress.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}" /> that represents the asynchronous operation.
    /// The task result contains the compressed data as a stream.
    /// </returns>
    Task<Stream> CompressAsync(Stream source, CancellationToken cancellationToken);

    /// <summary>
    /// Decompresses a sequence of bytes asynchronously.
    /// </summary>
    /// <param name="data">The sequence of bytes to decompress.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}" /> that represents the asynchronous operation.
    /// The task result contains the decompressed data as a sequence of bytes.
    /// </returns>
    Task<IEnumerable<byte>> DecompressAsync(IEnumerable<byte> data, CancellationToken cancellationToken);

    /// <summary>
    /// Decompresses a stream asynchronously.
    /// </summary>
    /// <param name="source">The stream to decompress.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}" /> that represents the asynchronous operation.
    /// The task result contains the decompressed data as a stream.
    /// </returns>
    Task<Stream> DecompressAsync(Stream source, CancellationToken cancellationToken);
}