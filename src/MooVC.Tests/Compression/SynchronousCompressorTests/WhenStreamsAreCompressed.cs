namespace MooVC.Compression.SynchronousCompressorTests
{
    using System.IO;
    using System.Threading.Tasks;
    using MooVC.IO;
    using Xunit;

    public sealed class WhenStreamsAreCompressed
    {
        [Fact]
        public async Task GivenAStreamThenTheResultMatchesAsync()
        {
            byte[] expected = new byte[] { 1, 2, 3 };
            using var stream = new MemoryStream(expected);
            var compressor = new TestableSynchronousCompressor();
            using Stream compressed = await compressor.CompressAsync(stream);

            Assert.NotEqual(expected, compressed.GetBytes());

            using Stream decompressed = await compressor.DecompressAsync(compressed);

            Assert.Equal(expected, decompressed.GetBytes());
        }
    }
}