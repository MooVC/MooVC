#if NET6_0_OR_GREATER
namespace MooVC.Compression.BrotliCompressorTests;

using System.IO;
using System.Security.Cryptography;
using System.Text;
using MooVC.IO;

public sealed class WhenStreamsAreCompressed
{
    [Fact]
    public async Task GivenAStreamThenTheResultMatches()
    {
        // Arrange
        byte[] expected = new byte[32768];
        var random = RandomNumberGenerator.Create();
        random.GetNonZeroBytes(expected);

        var compressor = new BrotliCompressor();
        using var stream = new MemoryStream(expected);

        // Act
        using Stream compressed = await compressor.Compress(stream, CancellationToken.None);

        // Assert
        IEnumerable<byte> compressedBytes = compressed.GetBytes();
        compressedBytes.ShouldNotBe(expected);

        // Act
        compressed.Position = 0;
        using Stream decompressed = await compressor.Decompress(compressed, CancellationToken.None);

        // Assert
        IEnumerable<byte> decompressedBytes = decompressed.GetBytes();
        decompressedBytes.ShouldBe(expected);
    }

    [Fact]
    public async Task GivenAnEmptyStreamThenTheResultMatches()
    {
        // Arrange
        byte[] expected = [];

        var compressor = new BrotliCompressor();
        using var stream = new MemoryStream(expected);

        // Act
        using Stream compressed = await compressor.Compress(stream, CancellationToken.None);

        compressed.Position = 0;

        using Stream decompressed = await compressor.Decompress(compressed, CancellationToken.None);

        // Assert
        IEnumerable<byte> decompressedBytes = decompressed.GetBytes();
        decompressedBytes.ShouldBe(expected);
    }
}
#endif