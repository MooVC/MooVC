namespace MooVC.Infrastructure.Compression.LZ4;

using System.IO;
using K4os.Compression.LZ4.Streams;
using MooVC.Compression;

public sealed class Compressor
    : SynchronousCompressor
{
    public Compressor(LZ4DecoderSettings? decoder = default, LZ4EncoderSettings? encoder = default)
    {
        Decoder = decoder ?? new LZ4DecoderSettings();
        Encoder = encoder ?? new LZ4EncoderSettings();
    }

    public LZ4DecoderSettings Decoder { get; }

    public LZ4EncoderSettings Encoder { get; }

    protected override Stream PerformCompress(Stream source)
    {
        var result = new MemoryStream();

        using LZ4EncoderStream encoded = LZ4Stream.Encode(result, settings: Encoder, leaveOpen: true);

        source.CopyTo(encoded);

        return result;
    }

    protected override Stream PerformDecompress(Stream source)
    {
        var result = new MemoryStream();

        using LZ4DecoderStream decoded = LZ4Stream.Decode(source, settings: Decoder, leaveOpen: true);

        decoded.CopyTo(result);

        return result;
    }
}