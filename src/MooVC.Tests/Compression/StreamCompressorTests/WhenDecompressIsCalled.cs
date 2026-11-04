namespace MooVC.Compression.StreamCompressorTests;

using System.IO;
using System.IO.Compression;
using System.Text;

public sealed class WhenDecompressIsCalled
{
    [Test]
    public async Task GivenOptionsChangedAfterConstructionThenOriginalSettingsAreUsed()
    {
        // Arrange
        const int bufferSize = 1;
        const string payload = "Stream contents survive a round trip with a one byte buffer.";
        byte[] expected = Encoding.UTF8.GetBytes(payload);
        var options = new StreamCompressor.Options { BufferSize = bufferSize, Level = CompressionLevel.Fastest };
        var compressor = new TestableStreamCompressor(options);
        using var source = new MemoryStream(expected);
        using Stream compressed = await compressor.Compress(source, CancellationToken.None);
        compressed.Position = 0;
        options.BufferSize = 0;
        options.Level = CompressionLevel.NoCompression;

        // Act
        using Stream decompressed = await compressor.Decompress(compressed, CancellationToken.None);

        // Assert
        _ = await Assert.That(compressor.DecompressionLevel).IsEqualTo(CompressionLevel.Fastest);
        _ = await Assert.That(((MemoryStream)decompressed).ToArray().SequenceEqual(expected)).IsTrue();
        _ = await Assert.That(compressed.CanRead).IsTrue();
        _ = await Assert.That(decompressed.CanRead).IsTrue();
    }

    [Test]
    public async Task GivenCancelledTokenThenCancellationIsPropagated()
    {
        // Arrange
        var compressor = new TestableStreamCompressor(new StreamCompressor.Options());
        using var source = new MemoryStream([1]);
        using Stream compressed = await compressor.Compress(source, CancellationToken.None);
        compressed.Position = 0;
        using var cancellation = new CancellationTokenSource();
        await cancellation.CancelAsync();

        // Act
        Func<Task> act = async () => await compressor.Decompress(compressed, cancellation.Token);

        // Assert
        _ = await Assert.That(act).Throws<OperationCanceledException>();
        _ = await Assert.That(compressed.CanRead).IsTrue();
    }
}