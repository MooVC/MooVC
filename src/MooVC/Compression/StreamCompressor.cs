namespace MooVC.Compression;

using System.IO.Compression;
using Ardalis.GuardClauses;
using static MooVC.Compression.StreamCompressor_Resources;

/// <summary>
/// Represents a class that uses the Brotli algorithm to compress and decompress streams.
/// </summary>
public abstract class StreamCompressor
    : Compressor
{
    /// <summary>
    /// The default buffer size for stream copy operations.
    /// </summary>
    public const int DefaultBufferSize = 81920;

    private readonly int _bufferSize;
    private readonly CompressionLevel _level;

    /// <summary>
    /// Initializes a new instance of the <see cref="BrotliCompressor" /> class.
    /// </summary>
    /// <param name="bufferSize">The buffer size to use when copying from one stream to another.</param>
    /// <param name="level">The <see cref="CompressionLevel" /> to use for compression and decompression.</param>
    protected StreamCompressor(int bufferSize = DefaultBufferSize, CompressionLevel level = CompressionLevel.Optimal)
    {
        _bufferSize = Guard.Against.NegativeOrZero(bufferSize, message: BufferSizeRequired);
        _level = Guard.Against.EnumOutOfRange(level, message: LevelRequired);
    }

    /// <summary>
    /// Asynchronously compresses the specified stream using the Brotli algorithm.
    /// </summary>
    /// <param name="source">The stream to compress.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task{TResult}" /> that represents the asynchronous operation, containing the compressed stream as the result.</returns>
    public override async Task<Stream> Compress(Stream source, CancellationToken cancellationToken)
    {
        var compressed = new MemoryStream();

        using Stream compressor = CreateCompressor(_level, compressed);

        await source
            .CopyToAsync(compressor, _bufferSize, cancellationToken)
            .ConfigureAwait(false);

        return compressed;
    }

    /// <summary>
    /// Asynchronously decompresses the specified stream using the Brotli algorithm.
    /// </summary>
    /// <param name="source">The stream to decompress.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}" /> that represents the asynchronous operation, containing the decompressed stream as the result.
    /// </returns>
    public override async Task<Stream> Decompress(Stream source, CancellationToken cancellationToken)
    {
        var decompressed = new MemoryStream();

        using Stream decompressor = CreateDecompressor(_level, source);

        await decompressor
            .CopyToAsync(decompressed, _bufferSize, cancellationToken)
            .ConfigureAwait(false);

        return decompressed;
    }

    /// <summary>
    /// Wraps the <paramref name="source" /> in a new <see cref="Stream" /> that is configured for compression based on the <paramref name="level" />.
    /// </summary>
    /// <param name="level">The <see cref="CompressionLevel" /> to use for compression.</param>
    /// <param name="source">The <see cref="Stream" /> to compress.</param>
    /// <returns>The wrapped <paramref name="source" /> configured for compression based on the <paramref name="level" />.</returns>
    protected abstract Stream CreateCompressor(CompressionLevel level, Stream source);

    /// <summary>
    /// Wraps the <paramref name="source" /> in a new <see cref="Stream" /> that is configured for decompression based on the <paramref name="level" />.
    /// </summary>
    /// <param name="level">The <see cref="CompressionLevel" /> to use for decompression.</param>
    /// <param name="source">The <see cref="Stream" /> to compress.</param>
    /// <returns>The wrapped <paramref name="source" /> configured for decompression based on the <paramref name="level" />.</returns>
    protected abstract Stream CreateDecompressor(CompressionLevel level, Stream source);
}