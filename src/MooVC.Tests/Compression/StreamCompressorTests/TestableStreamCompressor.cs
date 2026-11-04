namespace MooVC.Compression.StreamCompressorTests;

using System.IO;
using System.IO.Compression;

internal sealed class TestableStreamCompressor
    : StreamCompressor
{
    public TestableStreamCompressor(StreamCompressor.Options options)
        : base(options)
    {
    }

    public TestableStreamCompressor(int bufferSize = DefaultBufferSize, CompressionLevel level = CompressionLevel.Optimal)
        : base(bufferSize: bufferSize, level: level)
    {
    }

    public CompressionLevel CompressionLevel { get; private set; }

    public CompressionLevel DecompressionLevel { get; private set; }

    protected override Stream CreateCompressor(CompressionLevel level, Stream source)
    {
        CompressionLevel = level;

        return new GZipStream(source, level, true);
    }

    protected override Stream CreateDecompressor(CompressionLevel level, Stream source)
    {
        DecompressionLevel = level;

        return new GZipStream(source, CompressionMode.Decompress, true);
    }
}