namespace MooVC.Compression.DeflateCompressorTests;

using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MooVC.IO;
using Xunit;

public sealed class WhenStreamsAreCompressed
{
    [Fact]
    public async Task GivenAStreamThenTheResultMatchesAsync()
    {
        byte[] expected = new byte[32768];
        var random = RandomNumberGenerator.Create();

        random.GetNonZeroBytes(expected);

        var compressor = new DeflateCompressor();
        using var stream = new MemoryStream(expected);
        using Stream compressed = await compressor.CompressAsync(stream);

        Assert.NotEqual(expected, compressed.GetBytes());

        compressed.Position = 0;

        using Stream decompressed = await compressor.DecompressAsync(compressed);

        Assert.Equal(expected, decompressed.GetBytes());
    }
}