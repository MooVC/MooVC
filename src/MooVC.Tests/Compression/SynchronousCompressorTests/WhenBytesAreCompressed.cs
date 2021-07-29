namespace MooVC.Compression.SynchronousCompressorTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenBytesAreCompressed
    {
        [Fact]
        public async Task GivenBytesThenTheResultMatchesAsync()
        {
            IEnumerable<byte> expected = new byte[] { 1, 2, 3 };
            var compressor = new TestableSynchronousCompressor();
            IEnumerable<byte> compressed = await compressor.CompressAsync(expected);

            Assert.NotEqual(expected, compressed);

            IEnumerable<byte> decompressed = await compressor.DecompressAsync(compressed);

            Assert.Equal(expected, decompressed);
        }
    }
}