namespace MooVC.Compression.SynchronousCompressorTests;

using System.Security.Cryptography;

public sealed class WhenBytesAreCompressed
{
    [Fact]
    public async Task GivenBytesThenTheResultMatchesAsync()
    {
        // Arrange
        byte[] expected = new byte[32768];
        var random = RandomNumberGenerator.Create();
        random.GetNonZeroBytes(expected);

        var compressor = new TestableSynchronousCompressor();

        // Act
        IEnumerable<byte> compressed = await compressor.CompressAsync(expected, CancellationToken.None);

        // Assert
        _ = compressed.Should().NotEqual(expected);

        // Act
        IEnumerable<byte> decompressed = await compressor.DecompressAsync(compressed, CancellationToken.None);

        // Assert
        _ = decompressed.Should().Equal(expected);
    }

    [Fact]
    public async Task GivenNoBytesThenTheResultMatchesAsync()
    {
        // Arrange
        byte[] expected = [];

        var compressor = new TestableSynchronousCompressor();

        // Act
        IEnumerable<byte> compressed = await compressor.CompressAsync(expected, CancellationToken.None);
        IEnumerable<byte> decompressed = await compressor.DecompressAsync(compressed, CancellationToken.None);

        // Assert
        _ = decompressed.Should().Equal(expected);
    }
}