namespace MooVC.Infrastructure.Compression.LZ4.CompressorTests;

using System.Security.Cryptography;
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

        var compressor = new Compressor();
        using var stream = new MemoryStream(expected);

        // Act & Assert
        using Stream compressed = await compressor.Compress(stream, CancellationToken.None);

        compressed.GetBytes().ShouldNotBe(expected);

        compressed.Position = 0;

        using Stream decompressed = await compressor.Decompress(compressed, CancellationToken.None);

        decompressed.GetBytes().ShouldBe(expected);
    }
}