namespace MooVC.Infrastructure.Compression.LZ4.CompressorTests;

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

        var compressor = new Compressor();

        // Act & Assert
        IEnumerable<byte> compressed = await compressor.Compress(expected, CancellationToken.None);

        compressed.ShouldNotBe(expected);

        IEnumerable<byte> decompressed = await compressor.Decompress(compressed, CancellationToken.None);

        decompressed.ShouldBe(expected);
    }
}