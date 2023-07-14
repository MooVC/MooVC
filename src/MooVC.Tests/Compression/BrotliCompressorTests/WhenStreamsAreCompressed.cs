#if NET6_0_OR_GREATER
namespace MooVC.Compression.BrotliCompressorTests;

using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MooVC.IO;
using Xunit;

public sealed class WhenStreamsAreCompressed
{
    [Fact]
    public async Task GivenAStreamThenTheResultMatchesAsync()
    {
        // Arrange
        byte[] expected = new byte[32768];
        var random = RandomNumberGenerator.Create();
        random.GetNonZeroBytes(expected);

        var compressor = new BrotliCompressor();
        using var stream = new MemoryStream(expected);

        // Act
        using Stream compressed = await compressor.CompressAsync(stream, CancellationToken.None);

        // Assert
        IEnumerable<byte> compressedBytes = compressed.GetBytes();
        _ = compressedBytes.Should().NotEqual(expected);

        // Act
        compressed.Position = 0;
        using Stream decompressed = await compressor.DecompressAsync(compressed, CancellationToken.None);

        // Assert
        IEnumerable<byte> decompressedBytes = decompressed.GetBytes();
        _ = decompressedBytes.Should().Equal(expected);
    }

    [Fact]
    public async Task GivenAnEmptyStreamThenTheResultMatchesAsync()
    {
        // Arrange
        byte[] expected = Array.Empty<byte>();

        var compressor = new BrotliCompressor();
        using var stream = new MemoryStream(expected);

        // Act
        using Stream compressed = await compressor.CompressAsync(stream, CancellationToken.None);

        compressed.Position = 0;

        using Stream decompressed = await compressor.DecompressAsync(compressed, CancellationToken.None);

        // Assert
        IEnumerable<byte> decompressedBytes = decompressed.GetBytes();
        _ = decompressedBytes.Should().Equal(expected);
    }
}
#endif