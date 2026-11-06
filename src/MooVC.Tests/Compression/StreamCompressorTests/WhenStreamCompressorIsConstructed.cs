namespace MooVC.Compression.StreamCompressorTests;

using System.IO.Compression;
using System.Reflection;
using System.Text;

public sealed class WhenStreamCompressorIsConstructed
{
    private const string Payload = "Existing stream compressor subclasses retain their constructor behavior.";

    [Test]
    public async Task GivenTheOriginalProtectedSignatureThenItsOptionalDefaultsArePreserved()
    {
        // Arrange & Act
        ConstructorInfo? constructor = typeof(StreamCompressor).GetConstructor(
            BindingFlags.Instance | BindingFlags.NonPublic,
            binder: null,
            types: [typeof(int), typeof(CompressionLevel)],
            modifiers: null);

        // Assert
        _ = await Assert.That(constructor).IsNotNull();
        _ = await Assert.That(constructor!.IsFamily).IsTrue();
        ParameterInfo[] parameters = constructor.GetParameters();
        _ = await Assert.That(parameters[0].Name).IsEqualTo("bufferSize");
        _ = await Assert.That(parameters[0].IsOptional).IsTrue();
        _ = await Assert.That(parameters[0].DefaultValue).IsEqualTo(StreamCompressor.DefaultBufferSize);
        _ = await Assert.That(parameters[1].Name).IsEqualTo("level");
        _ = await Assert.That(parameters[1].IsOptional).IsTrue();
        _ = await Assert.That(parameters[1].DefaultValue).IsEqualTo(CompressionLevel.Optimal);
    }

    [Test]
    public async Task GivenTheOriginalConstantThenItsPublicValueIsPreserved()
    {
        // Arrange
        const int expected = 81920;

        // Act
        FieldInfo? field = typeof(StreamCompressor).GetField(nameof(StreamCompressor.DefaultBufferSize));

        // Assert
        _ = await Assert.That(field).IsNotNull();
        _ = await Assert.That(field!.IsLiteral).IsTrue();
        _ = await Assert.That(field.GetRawConstantValue()).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenASubclassUsingTheOriginalDefaultConstructorThenDefaultSettingsAreUsed()
    {
        // Arrange
        var compressor = new TestableStreamCompressor();
        using var source = new RecordingStream(Encoding.UTF8.GetBytes(Payload));

        // Act
        using Stream compressed = await compressor.Compress(source, CancellationToken.None);

        // Assert
        _ = await Assert.That(source.BufferSize).IsEqualTo(StreamCompressor.DefaultBufferSize);
        _ = await Assert.That(compressor.CompressionLevel).IsEqualTo(CompressionLevel.Optimal);
        _ = await Assert.That(compressed.Length).IsGreaterThan(0);
    }

    [Test]
    [Arguments(1, CompressionLevel.Fastest)]
    [Arguments(128, CompressionLevel.NoCompression)]
    public async Task GivenASubclassUsingTheOriginalConstructorThenCustomSettingsAreUsed(int bufferSize, CompressionLevel level)
    {
        // Arrange
        byte[] expected = Encoding.UTF8.GetBytes(Payload);
        var compressor = new TestableStreamCompressor(bufferSize, level);
        using var source = new RecordingStream(expected);

        // Act
        using Stream compressed = await compressor.Compress(source, CancellationToken.None);
        compressed.Position = 0;
        using Stream decompressed = await compressor.Decompress(compressed, CancellationToken.None);

        // Assert
        _ = await Assert.That(source.BufferSize).IsEqualTo(bufferSize);
        _ = await Assert.That(compressor.CompressionLevel).IsEqualTo(level);
        _ = await Assert.That(compressor.DecompressionLevel).IsEqualTo(level);
        _ = await Assert.That(((MemoryStream)decompressed).ToArray().SequenceEqual(expected)).IsTrue();
    }

    private sealed class RecordingStream(byte[] data)
        : MemoryStream(data)
    {
        public int BufferSize { get; private set; }

        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            BufferSize = bufferSize;

            return base.CopyToAsync(destination, bufferSize, cancellationToken);
        }
    }
}