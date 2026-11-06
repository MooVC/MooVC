namespace MooVC.Compression.Configuration.OptionsTests;

using System.IO.Compression;

public sealed class WhenWithBrotliIsCalled
{
    [Test]
    public async Task GivenValueThenUpdatedCopyPreservesOtherSettings()
    {
        // Arrange
        var options = new Options { Type = DeflateCompressor.Deflate };
        var value = new StreamCompressor.Options { Level = CompressionLevel.Fastest };

        // Act
        Options result = options.WithBrotli(value);

        // Assert
        _ = await Assert.That(ReferenceEquals(result, options)).IsFalse();
        _ = await Assert.That(ReferenceEquals(result.Brotli, value)).IsTrue();
        _ = await Assert.That(ReferenceEquals(options.Brotli, value)).IsFalse();
        _ = await Assert.That(result.Type).IsEqualTo(options.Type);
        _ = await Assert.That(ReferenceEquals(result.GZip, options.GZip)).IsTrue();
        _ = await Assert.That(ReferenceEquals(result.Deflate, options.Deflate)).IsTrue();
    }
}