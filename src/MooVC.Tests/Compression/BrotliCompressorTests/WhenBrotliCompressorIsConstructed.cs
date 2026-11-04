namespace MooVC.Compression.BrotliCompressorTests;

using System.ComponentModel;
using System.IO.Compression;
using System.Text;
using static MooVC.Compression.StreamCompressor_Resources;

public sealed class WhenBrotliCompressorIsConstructed
{
    [Test]
    [Arguments(-1)]
    [Arguments(0)]
    public async Task GivenAnInvalidBufferSizeThenAnArgumentExceptionIsThrown(int bufferSize)
    {
        // Arrange
        var options = new StreamCompressor.Options { BufferSize = bufferSize };

        // Act
        Func<ICompressor> act = () => new BrotliCompressor(options);

        // Assert
        _ = await Assert.That(act).Throws<ArgumentException>();
    }

    [Test]
    [Arguments((CompressionLevel)(-1))]
    [Arguments((CompressionLevel)9)]
    public async Task GivenAnInvalidLevelThenAnInvalidEnumArgumentExceptionIsThrown(CompressionLevel level)
    {
        // Arrange
        var options = new StreamCompressor.Options { Level = level };

        // Act
        Func<ICompressor> act = () => new BrotliCompressor(options);

        // Assert
        _ = await Assert.That(act).Throws<InvalidEnumArgumentException>();
    }

    [Test]
    public async Task GivenDefaultOptionsThenAnInstanceIsCreated()
    {
        // Arrange
        var options = new StreamCompressor.Options();

        // Act
        var compressor = new BrotliCompressor(options);

        // Assert
        _ = await Assert.That(compressor).IsNotNull();
    }

    [Test]
    public async Task GivenNullOptionsThenAnArgumentNullExceptionIsThrown()
    {
        // Act
        Func<ICompressor> act = () => new BrotliCompressor(null!);

        // Assert
        _ = await Assert.That(act).Throws<ArgumentNullException>();
    }

    [Test]
    [Arguments(CompressionLevel.Optimal)]
    [Arguments(CompressionLevel.Fastest)]
    [Arguments(CompressionLevel.NoCompression)]
    [Arguments(CompressionLevel.SmallestSize)]
    public async Task GivenAValidLevelThenAnInstanceIsCreated(CompressionLevel level)
    {
        // Arrange
        var options = new StreamCompressor.Options { Level = level };

        // Act
        var compressor = new BrotliCompressor(options);

        // Assert
        _ = await Assert.That(compressor).IsNotNull();
    }

    [Test]
    [Arguments(1)]
    [Arguments(StreamCompressor.Options.DefaultBufferSize)]
    public async Task GivenAValidBufferSizeThenAnInstanceIsCreated(int bufferSize)
    {
        // Arrange
        var options = new StreamCompressor.Options { BufferSize = bufferSize };

        // Act
        var compressor = new BrotliCompressor(options);

        // Assert
        _ = await Assert.That(compressor).IsNotNull();
    }

    [Test]
    public async Task GivenNoArgumentsThenCompressionMatchesDefaultOptions()
    {
        // Act
        var compressor = new BrotliCompressor();

        // Assert
        await AssertCompressionMatches(compressor, new StreamCompressor.Options());
    }

    [Test]
    [Arguments(1)]
    [Arguments(StreamCompressor.DefaultBufferSize)]
    public async Task GivenABufferArgumentThenPositionalAndNamedCallsMatchOptions(int bufferSize)
    {
        // Arrange
        var options = new StreamCompressor.Options { BufferSize = bufferSize };

        // Act
        var positional = new BrotliCompressor(bufferSize);
        var named = new BrotliCompressor(bufferSize: bufferSize);

        // Assert
        await AssertCompressionMatches(positional, options);
        await AssertCompressionMatches(named, options);
    }

    [Test]
    [Arguments(CompressionLevel.Optimal)]
    [Arguments(CompressionLevel.Fastest)]
    [Arguments(CompressionLevel.NoCompression)]
    [Arguments(CompressionLevel.SmallestSize)]
    public async Task GivenALevelArgumentThenTheNamedCallMatchesOptions(CompressionLevel level)
    {
        // Arrange
        var options = new StreamCompressor.Options { Level = level };

        // Act
        var compressor = new BrotliCompressor(level: level);

        // Assert
        await AssertCompressionMatches(compressor, options);
    }

    [Test]
    [Arguments(1, CompressionLevel.Fastest)]
    [Arguments(StreamCompressor.DefaultBufferSize, CompressionLevel.NoCompression)]
    public async Task GivenBothArgumentsThenPositionalAndNamedCallsMatchOptions(int bufferSize, CompressionLevel level)
    {
        // Arrange
        var options = new StreamCompressor.Options { BufferSize = bufferSize, Level = level };

        // Act
        var positional = new BrotliCompressor(bufferSize, level);
        var named = new BrotliCompressor(level: level, bufferSize: bufferSize);

        // Assert
        await AssertCompressionMatches(positional, options);
        await AssertCompressionMatches(named, options);
    }

    [Test]
    [Arguments(-1)]
    [Arguments(0)]
    public async Task GivenAnInvalidBufferArgumentThenAnArgumentExceptionNamesTheParameter(int bufferSize)
    {
        // Act
        Func<ICompressor> act = () => new BrotliCompressor(bufferSize: bufferSize);

        // Assert
        ArgumentException exception = await Assert.That(act).Throws<ArgumentException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(bufferSize));
    }

    [Test]
    [Arguments((CompressionLevel)(-1))]
    [Arguments((CompressionLevel)9)]
    public async Task GivenAnInvalidLevelArgumentThenAnInvalidEnumArgumentExceptionIsThrown(CompressionLevel level)
    {
        // Act
        Func<ICompressor> act = () => new BrotliCompressor(level: level);

        // Assert
        InvalidEnumArgumentException exception = await Assert.That(act).Throws<InvalidEnumArgumentException>().And.IsNotNull();
        _ = await Assert.That(exception.Message).IsEqualTo(LevelRequired);
        _ = await Assert.That(exception.ParamName).IsNull();
    }

    private static async Task AssertCompressionMatches(ICompressor compressor, StreamCompressor.Options options)
    {
        const string Payload = "Compression compatibility payload. Compression compatibility payload. Compression compatibility payload.";
        byte[] payload = Encoding.UTF8.GetBytes(Payload);
        var expected = new BrotliCompressor(options);

        IEnumerable<byte> compressed = await compressor.Compress(payload, CancellationToken.None);
        IEnumerable<byte> expectedCompressed = await expected.Compress(payload, CancellationToken.None);
        IEnumerable<byte> decompressed = await compressor.Decompress(expectedCompressed, CancellationToken.None);

        _ = await Assert.That(compressed.SequenceEqual(expectedCompressed)).IsTrue();
        _ = await Assert.That(decompressed.SequenceEqual(payload)).IsTrue();
    }
}