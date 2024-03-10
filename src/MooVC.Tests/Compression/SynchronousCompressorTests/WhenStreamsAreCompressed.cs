namespace MooVC.Compression.SynchronousCompressorTests;

using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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

        var compressor = new TestableSynchronousCompressor();
        using var stream = new MemoryStream(expected);

        // Act
        using Stream compressed = await compressor.Compress(stream, CancellationToken.None);

        // Assert
        IEnumerable<byte> compressedBytes = compressed.GetBytes();
        _ = compressedBytes.Should().NotEqual(expected);

        // Act
        compressed.Position = 0;
        using Stream decompressed = await compressor.Decompress(compressed, CancellationToken.None);

        // Assert
        IEnumerable<byte> decompressedBytes = decompressed.GetBytes();
        _ = decompressedBytes.Should().Equal(expected);
    }

    [Fact]
    public async Task GivenAnEmptyStreamThenTheResultMatches()
    {
        // Arrange
        byte[] expected = [];

        var compressor = new TestableSynchronousCompressor();
        using var stream = new MemoryStream(expected);

        // Act
        using Stream compressed = await compressor.Compress(stream, CancellationToken.None);

        compressed.Position = 0;

        using Stream decompressed = await compressor.Decompress(compressed, CancellationToken.None);

        // Assert
        IEnumerable<byte> decompressedBytes = decompressed.GetBytes();
        _ = decompressedBytes.Should().Equal(expected);
    }
}