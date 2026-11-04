namespace MooVC.Compression.DeflateCompressorTests.FactoryTests;

using System.ComponentModel;
using System.Globalization;
using System.IO.Compression;
using System.Text;
using Microsoft.Extensions.Configuration;
using Type = MooVC.Compression.Configuration.Type;

public sealed class WhenTryCreateIsCalled
{
    private const string BufferSizeKey = "Compression:BufferSize";
    private const string LevelKey = "Compression:Level";
    private const string Payload = "A repeated compression payload. A repeated compression payload. A repeated compression payload.";
    private const string SectionName = "Compression";

    [Test]
    [Arguments(CompressionLevel.Optimal)]
    [Arguments(CompressionLevel.Fastest)]
    [Arguments(CompressionLevel.NoCompression)]
    [Arguments(CompressionLevel.SmallestSize)]
    public async Task GivenMatchingTypeThenConfiguredCompressorIsCreated(CompressionLevel level)
    {
        // Arrange
        const int bufferSize = 1;
        var factory = new DeflateCompressor.Factory();
        var settings = new Dictionary<string, string?>
        {
            [BufferSizeKey] = bufferSize.ToString(CultureInfo.InvariantCulture),
            [LevelKey] = level.ToString(),
        };
        IConfigurationSection configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(settings)
            .Build()
            .GetSection(SectionName);
        byte[] payload = Encoding.UTF8.GetBytes(Payload);
        var expected = new DeflateCompressor(new StreamCompressor.Options { BufferSize = bufferSize, Level = level });

        // Act
        bool result = factory.TryCreate(configuration, DeflateCompressor.Deflate, out ICompressor compressor);
        IEnumerable<byte> compressed = await compressor.Compress(payload, CancellationToken.None);
        IEnumerable<byte> expectedCompressed = await expected.Compress(payload, CancellationToken.None);
        IEnumerable<byte> decompressed = await compressor.Decompress(compressed, CancellationToken.None);

        // Assert
        _ = await Assert.That(result).IsTrue();
        _ = await Assert.That(compressor).IsTypeOf<DeflateCompressor>();
        _ = await Assert.That(compressed.SequenceEqual(expectedCompressed)).IsTrue();
        _ = await Assert.That(decompressed.SequenceEqual(payload)).IsTrue();
    }

    [Test]
    [Arguments(-1)]
    [Arguments(0)]
    public async Task GivenMatchingTypeAndInvalidBufferSizeThenAnArgumentExceptionIsThrown(int bufferSize)
    {
        // Arrange
        var factory = new DeflateCompressor.Factory();
        IConfigurationSection configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?> { [BufferSizeKey] = bufferSize.ToString(CultureInfo.InvariantCulture) })
            .Build()
            .GetSection(SectionName);

        // Act
        Action act = () => factory.TryCreate(configuration, DeflateCompressor.Deflate, out _);

        // Assert
        _ = await Assert.That(act).Throws<ArgumentException>();
    }

    [Test]
    public async Task GivenMatchingTypeAndInvalidLevelThenAnInvalidEnumArgumentExceptionIsThrown()
    {
        // Arrange
        const string invalidLevel = "99";
        var factory = new DeflateCompressor.Factory();
        IConfigurationSection configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?> { [LevelKey] = invalidLevel })
            .Build()
            .GetSection(SectionName);

        // Act
        Action act = () => factory.TryCreate(configuration, DeflateCompressor.Deflate, out _);

        // Assert
        _ = await Assert.That(act).Throws<InvalidEnumArgumentException>();
    }

    [Test]
    public async Task GivenMatchingTypeAndMalformedOptionsThenAnInvalidOperationExceptionIsThrown()
    {
        // Arrange
        const string invalidBufferSize = "invalid";
        var factory = new DeflateCompressor.Factory();
        IConfigurationSection configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?> { [BufferSizeKey] = invalidBufferSize })
            .Build()
            .GetSection(SectionName);

        // Act
        Action act = () => factory.TryCreate(configuration, DeflateCompressor.Deflate, out _);

        // Assert
        _ = await Assert.That(act).Throws<InvalidOperationException>();
    }

    [Test]
    [Arguments("None")]
    [Arguments("Unknown")]
    [Arguments("deflate")]
    public async Task GivenAnotherTypeThenNoCompressorIsCreated(string value)
    {
        // Arrange
        var factory = new DeflateCompressor.Factory();
        Type type = value;

        // Act
        bool result = factory.TryCreate(null!, type, out ICompressor compressor);

        // Assert
        _ = await Assert.That(result).IsFalse();
        _ = await Assert.That(compressor).IsNull();
    }

    [Test]
    public async Task GivenDefaultTypeThenNoCompressorIsCreated()
    {
        // Arrange
        var factory = new DeflateCompressor.Factory();

        // Act
        bool result = factory.TryCreate(null!, default, out ICompressor compressor);

        // Assert
        _ = await Assert.That(result).IsFalse();
        _ = await Assert.That(compressor).IsNull();
    }

    [Test]
    public async Task GivenRepeatedRequestsThenDistinctCompressorsAreCreated()
    {
        // Arrange
        const string bufferSize = "16";
        var factory = new DeflateCompressor.Factory();
        IConfigurationSection configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?> { [BufferSizeKey] = bufferSize })
            .Build()
            .GetSection(SectionName);

        // Act
        _ = factory.TryCreate(configuration, DeflateCompressor.Deflate, out ICompressor first);
        _ = factory.TryCreate(configuration, DeflateCompressor.Deflate, out ICompressor second);

        // Assert
        _ = await Assert.That(first).IsNotStrictlyEqualTo(second);
    }
}