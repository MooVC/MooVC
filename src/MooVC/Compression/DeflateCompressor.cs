namespace MooVC.Compression;

using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using static MooVC.Compression.Resources;
using static MooVC.Ensure;

/// <summary>
/// Represents a class that uses the Deflate algorithm to compress and decompress streams.
/// </summary>
public sealed class DeflateCompressor
    : Compressor
{
    private readonly CompressionLevel level;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeflateCompressor"/> class.
    /// </summary>
    /// <param name="level">The <see cref="CompressionLevel"/> to use for compression and decompression.</param>
    public DeflateCompressor(CompressionLevel level = CompressionLevel.SmallestSize)
    {
        this.level = IsDefined(level, message: DeflateCompressorLevelRequired);
    }

    /// <summary>
    /// Asynchronously compresses the specified stream using the Deflate algorithm.
    /// </summary>
    /// <param name="source">The stream to compress.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous operation, containing the compressed stream as the result.</returns>
    public override async Task<Stream> CompressAsync(Stream source, CancellationToken? cancellationToken = default)
    {
        var result = new MemoryStream();

        using var compressor = new DeflateStream(result, level, true);

        await source
            .CopyToAsync(compressor, cancellationToken.GetValueOrDefault())
            .ConfigureAwait(false);

        return result;
    }

    /// <summary>
    /// Asynchronously decompresses the specified stream using the Deflate algorithm.
    /// </summary>
    /// <param name="source">The stream to decompress.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous operation, containing the decompressed stream
    /// as the result.</returns>
    public override async Task<Stream> DecompressAsync(Stream source, CancellationToken? cancellationToken = null)
    {
        var result = new MemoryStream();

        using var decompressor = new DeflateStream(source, CompressionMode.Decompress, true);

        await decompressor
            .CopyToAsync(result, cancellationToken.GetValueOrDefault())
            .ConfigureAwait(false);

        return result;
    }
}