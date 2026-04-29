namespace MooVC.Infrastructure.Compression.LZ4;

using System.Diagnostics;
using System.IO;
using K4os.Compression.LZ4.Streams;
using MooVC.Compression;

/// <summary>
/// Compresses and decompresses payloads using the LZ4 algorithm.
/// </summary>
/// <remarks>
/// Uses <see cref="LZ4Stream" /> wrappers for stream transformation and materializes results in memory for compatibility with synchronous abstractions.
/// </remarks>
[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
public sealed class Compressor
    : SynchronousCompressor
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Compressor"/> class.
    /// </summary>
    /// <param name="decoder">The decoder settings used during decompression operations.</param>
    /// <param name="encoder">The encoder settings used during compression operations.</param>
    public Compressor(LZ4DecoderSettings? decoder = default, LZ4EncoderSettings? encoder = default)
    {
        Decoder = decoder ?? new LZ4DecoderSettings();
        Encoder = encoder ?? new LZ4EncoderSettings();
    }

    /// <summary>
    /// Gets the decoder settings used when decompressing streams.
    /// </summary>
    public LZ4DecoderSettings Decoder { get; }

    /// <summary>
    /// Gets the encoder settings used when compressing streams.
    /// </summary>
    public LZ4EncoderSettings Encoder { get; }

    /// <summary>
    /// Compresses the provided <paramref name="source"/> stream into an in-memory LZ4 payload.
    /// </summary>
    /// <param name="source">The source stream containing uncompressed data.</param>
    /// <returns>A <see cref="Stream"/> positioned at the beginning of compressed content.</returns>
    protected override Stream PerformCompress(Stream source)
    {
        var result = new MemoryStream();

        // Keep the memory stream open so the compressed payload can be returned to callers.
        using LZ4EncoderStream encoded = LZ4Stream.Encode(result, settings: Encoder, leaveOpen: true);

        source.CopyTo(encoded);

        return result;
    }

    /// <summary>
    /// Decompresses the provided <paramref name="source"/> stream into an in-memory payload.
    /// </summary>
    /// <param name="source">The source stream containing LZ4-compressed data.</param>
    /// <returns>A <see cref="Stream"/> positioned at the beginning of decompressed content.</returns>
    protected override Stream PerformDecompress(Stream source)
    {
        var result = new MemoryStream();

        // Keep source and target streams available after the decoder is disposed.
        using LZ4DecoderStream decoded = LZ4Stream.Decode(source, settings: Decoder, leaveOpen: true);

        decoded.CopyTo(result);

        return result;
    }

    private string GetDebuggerDisplay()
    {
        return $"{nameof(Compressor)} {{ " +
            $"{nameof(Decoder)} = {DebuggerDisplayFormatter.Format(Decoder)}, " +
            $"{nameof(Encoder)} = {DebuggerDisplayFormatter.Format(Encoder)} }}";
    }
}