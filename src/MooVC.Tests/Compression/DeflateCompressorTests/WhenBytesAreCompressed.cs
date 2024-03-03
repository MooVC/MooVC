namespace MooVC.Compression.DeflateCompressorTests;

using System.IO.Compression;
using System.Security.Cryptography;

public sealed class WhenBytesAreCompressed
{
    [Fact]
    public async Task GivenBytesThenTheResultMatches()
    {
        // Arrange
        byte[] expected = new byte[32768];
        var random = RandomNumberGenerator.Create();
        random.GetNonZeroBytes(expected);

        var compressor = new DeflateCompressor(level: CompressionLevel.Fastest);

        // Act
        IEnumerable<byte> compressed = await compressor.Compress(expected, CancellationToken.None);

        // Assert
        _ = compressed.Should().NotEqual(expected);

        // Act
        IEnumerable<byte> decompressed = await compressor.Decompress(compressed, CancellationToken.None);

        // Assert
        _ = decompressed.Should().Equal(expected);
    }

    [Fact]
    public async Task GivenNoBytesThenTheResultMatches()
    {
        // Arrange
        byte[] expected = [];

        var compressor = new DeflateCompressor(level: CompressionLevel.Fastest);

        // Act
        IEnumerable<byte> compressed = await compressor.Compress(expected, CancellationToken.None);
        IEnumerable<byte> decompressed = await compressor.Decompress(compressed, CancellationToken.None);

        // Assert
        _ = decompressed.Should().Equal(expected);
    }
}