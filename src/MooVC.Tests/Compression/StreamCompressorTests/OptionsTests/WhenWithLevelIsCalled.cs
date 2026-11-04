namespace MooVC.Compression.StreamCompressorTests.OptionsTests;

using System.IO.Compression;

public sealed class WhenWithLevelIsCalled
{
    [Test]
    public async Task GivenValueThenUpdatedCopyPreservesOtherSettings()
    {
        // Arrange
        const int bufferSize = 1;
        var options = new StreamCompressor.Options { BufferSize = bufferSize };

        // Act
        StreamCompressor.Options result = options.WithLevel(CompressionLevel.Fastest);

        // Assert
        _ = await Assert.That(ReferenceEquals(result, options)).IsFalse();
        _ = await Assert.That(result.BufferSize).IsEqualTo(bufferSize);
        _ = await Assert.That(result.Level).IsEqualTo(CompressionLevel.Fastest);
        _ = await Assert.That(options.Level).IsEqualTo(CompressionLevel.Optimal);
    }
}