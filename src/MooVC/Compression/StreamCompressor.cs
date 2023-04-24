namespace MooVC.Compression;

using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using static MooVC.Compression.Resources;
using static MooVC.Ensure;

/// <summary>
/// Represents a class that uses the Brotli algorithm to compress and decompress streams.
/// </summary>
public abstract class StreamCompressor
    : Compressor
{
    private readonly CompressionLevel level;

    /// <summary>
    /// Initializes a new instance of the <see cref="BrotliCompressor"/> class.
    /// </summary>
    /// <param name="level">The <see cref="CompressionLevel"/> to use for compression and decompression.</param>
    protected StreamCompressor(CompressionLevel level = CompressionLevel.SmallestSize)
    {
        this.level = IsDefined(level, message: StreamCompressorLevelRequired);
    }

    /// <summary>
    /// Asynchronously compresses the specified stream using the Brotli algorithm.
    /// </summary>
    /// <param name="source">The stream to compress.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous operation, containing the compressed stream as the result.</returns>
    public override async Task<Stream> CompressAsync(Stream source, CancellationToken cancellationToken = default)
    {
        var compressed = new MemoryStream();

        using Stream compressor = CreateCompressor(level, compressed);

        await source
            .CopyToAsync(compressor, cancellationToken)
            .ConfigureAwait(false);

        return compressed;
    }

    /// <summary>
    /// Asynchronously decompresses the specified stream using the Brotli algorithm.
    /// </summary>
    /// <param name="source">The stream to decompress.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous operation, containing the decompressed stream as the result.
    /// </returns>
    public override async Task<Stream> DecompressAsync(Stream source, CancellationToken cancellationToken = default)
    {
        var decompressed = new MemoryStream();

        using Stream decompressor = CreateDecompressor(level, source);

        await decompressor
            .CopyToAsync(decompressed, cancellationToken)
            .ConfigureAwait(false);

        return decompressed;
    }

    /// <summary>
    /// Wraps the <paramref name="source"/> in a new <see cref="Stream"/> that is configured for compression based on the <paramref name="level"/>.
    /// </summary>
    /// <param name="level">The <see cref="CompressionLevel"/> to use for compression.</param>
    /// <param name="source">The <see cref="Stream"/> to compress.</param>
    /// <returns>The wrapped <paramref name="source"/> configured for compression based on the <paramref name="level"/>.</returns>
    protected abstract Stream CreateCompressor(CompressionLevel level, Stream source);

    /// <summary>
    /// Wraps the <paramref name="source"/> in a new <see cref="Stream"/> that is configured for decompression based on the <paramref name="level"/>.
    /// </summary>
    /// <param name="level">The <see cref="CompressionLevel"/> to use for decompression.</param>
    /// <param name="source">The <see cref="Stream"/> to compress.</param>
    /// <returns>The wrapped <paramref name="source"/> configured for decompression based on the <paramref name="level"/>.</returns>
    protected abstract Stream CreateDecompressor(CompressionLevel level, Stream source);
}