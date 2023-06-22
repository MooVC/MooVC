namespace MooVC.Compression;

using System.IO;
using System.IO.Compression;

/// <summary>
/// Represents a class that uses the GZip algorithm to compress and decompress streams.
/// </summary>
public sealed class GZipCompressor
    : StreamCompressor
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GZipCompressor"/> class.
    /// </summary>
    /// <param name="bufferSize">The buffer size to use when copying from one stream to another.</param>
    /// <param name="level">The <see cref="CompressionLevel"/> to use for compression and decompression.</param>
    public GZipCompressor(int bufferSize = DefaultBufferSize, CompressionLevel level = CompressionLevel.Optimal)
        : base(bufferSize: bufferSize, level: level)
    {
    }

    /// <summary>
    /// Wraps the <paramref name="source"/> in a new <see cref="GZipStream"/> that is configured for compression based on the <paramref name="level"/>.
    /// </summary>
    /// <param name="level">The <see cref="CompressionLevel"/> to use for compression.</param>
    /// <param name="source">The <see cref="Stream"/> to compress.</param>
    /// <returns>The wrapped <paramref name="source"/> configured for compression based on the <paramref name="level"/>.</returns>
    protected override Stream CreateCompressor(CompressionLevel level, Stream source)
    {
        return new GZipStream(source, level, true);
    }

    /// <summary>
    /// Wraps the <paramref name="source"/> in a new <see cref="GZipStream"/> that is configured for decompression.
    /// </summary>
    /// <param name="level">The <see cref="CompressionLevel"/> to use for decompression.</param>
    /// <param name="source">The <see cref="Stream"/> to compress.</param>
    /// <returns>The wrapped <paramref name="source"/> configured for decompression based on the <paramref name="level"/>.</returns>
    protected override Stream CreateDecompressor(CompressionLevel level, Stream source)
    {
        return new GZipStream(source, CompressionMode.Decompress, true);
    }
}