namespace MooVC.Compression.GZipCompressorTests;

using System.IO.Compression;
using System.Security.Cryptography;

public sealed class WhenBytesAreCompressed
{
    [Test]
    public async Task GivenBytesThenTheResultMatches()
    {
        // Arrange
        byte[] expected = new byte[32768];
        var random = RandomNumberGenerator.Create();
        random.GetNonZeroBytes(expected);

        var compressor = new GZipCompressor(level: CompressionLevel.Fastest);

        // Act
        IEnumerable<byte> compressed = await compressor.Compress(expected, CancellationToken.None);

        // Assert
        _ = await Assert.That(compressed).IsNotEquivalentTo(expected);

        // Act
        IEnumerable<byte> decompressed = await compressor.Decompress(compressed, CancellationToken.None);

        // Assert
        _ = await Assert.That(decompressed).IsEquivalentTo(expected);
    }

    [Test]
    public async Task GivenNoBytesThenTheResultMatches()
    {
        // Arrange
        byte[] expected = [];

        var compressor = new GZipCompressor(level: CompressionLevel.Fastest);

        // Act
        IEnumerable<byte> compressed = await compressor.Compress(expected, CancellationToken.None);
        IEnumerable<byte> decompressed = await compressor.Decompress(compressed, CancellationToken.None);

        // Assert
        _ = await Assert.That(decompressed).IsEquivalentTo(expected);
    }
}