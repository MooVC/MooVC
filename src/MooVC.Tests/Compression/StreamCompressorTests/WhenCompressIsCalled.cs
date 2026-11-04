namespace MooVC.Compression.StreamCompressorTests;

using System.IO;
using System.IO.Compression;
using System.Text;

public sealed class WhenCompressIsCalled
{
    [Test]
    public async Task GivenOptionsChangedAfterConstructionThenOriginalSettingsAreUsed()
    {
        // Arrange
        const int bufferSize = 7;
        const string payload = "Compression settings are captured when the compressor is constructed.";
        var options = new StreamCompressor.Options { BufferSize = bufferSize, Level = CompressionLevel.Fastest };
        var compressor = new TestableStreamCompressor(options);
        using var source = new RecordingStream(Encoding.UTF8.GetBytes(payload));
        using var cancellation = new CancellationTokenSource();
        options.BufferSize = 0;
        options.Level = CompressionLevel.NoCompression;

        // Act
        using Stream compressed = await compressor.Compress(source, cancellation.Token);

        // Assert
        _ = await Assert.That(source.BufferSize).IsEqualTo(bufferSize);
        _ = await Assert.That(source.CancellationToken).IsEqualTo(cancellation.Token);
        _ = await Assert.That(compressor.CompressionLevel).IsEqualTo(CompressionLevel.Fastest);
        _ = await Assert.That(compressed.CanRead).IsTrue();
        _ = await Assert.That(source.CanRead).IsTrue();
    }

    [Test]
    public async Task GivenCancelledTokenThenCancellationIsPropagated()
    {
        // Arrange
        var compressor = new TestableStreamCompressor(new StreamCompressor.Options());
        using var source = new MemoryStream([1]);
        using var cancellation = new CancellationTokenSource();
        await cancellation.CancelAsync();

        // Act
        Func<Task> act = async () => await compressor.Compress(source, cancellation.Token);

        // Assert
        _ = await Assert.That(act).Throws<OperationCanceledException>();
        _ = await Assert.That(source.CanRead).IsTrue();
    }

    private sealed class RecordingStream(byte[] data)
        : MemoryStream(data)
    {
        public int BufferSize { get; private set; }

        public CancellationToken CancellationToken { get; private set; }

        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            BufferSize = bufferSize;
            CancellationToken = cancellationToken;

            return base.CopyToAsync(destination, bufferSize, cancellationToken);
        }
    }
}