namespace MooVC.Compression.BrotliCompressorTests;

using System.Collections.Generic;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Xunit;

public sealed class WhenBytesAreCompressed
{
    [Fact]
    public async Task GivenBytesThenTheResultMatchesAsync()
    {
        byte[] expected = new byte[32768];
        var random = RandomNumberGenerator.Create();

        random.GetNonZeroBytes(expected);

        var compressor = new BrotliCompressor(level: CompressionLevel.Fastest);
        IEnumerable<byte> compressed = await compressor.CompressAsync(expected);

        Assert.NotEqual(expected, compressed);

        IEnumerable<byte> decompressed = await compressor.DecompressAsync(compressed);

        Assert.Equal(expected, decompressed);
    }
}