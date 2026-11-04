namespace MooVC.Compression.StreamCompressorTests.OptionsTests;

using System.IO.Compression;

public sealed class WhenWithBufferSizeIsCalled
{
    [Test]
    public async Task GivenValueThenUpdatedCopyPreservesOtherSettings()
    {
        // Arrange
        const int bufferSize = 1;
        var options = new StreamCompressor.Options { Level = CompressionLevel.Fastest };

        // Act
        StreamCompressor.Options result = options.WithBufferSize(bufferSize);

        // Assert
        _ = await Assert.That(ReferenceEquals(result, options)).IsFalse();
        _ = await Assert.That(result.BufferSize).IsEqualTo(bufferSize);
        _ = await Assert.That(result.Level).IsEqualTo(options.Level);
        _ = await Assert.That(options.BufferSize).IsEqualTo(StreamCompressor.Options.DefaultBufferSize);
    }
}