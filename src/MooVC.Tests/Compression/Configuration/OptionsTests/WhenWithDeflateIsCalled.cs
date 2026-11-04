namespace MooVC.Compression.Configuration.OptionsTests;

using System.IO.Compression;

public sealed class WhenWithDeflateIsCalled
{
    [Test]
    public async Task GivenValueThenUpdatedCopyPreservesOtherSettings()
    {
        // Arrange
        var options = new Options { Type = DeflateCompressor.Deflate };
        var value = new StreamCompressor.Options { Level = CompressionLevel.Fastest };

        // Act
        Options result = options.WithDeflate(value);

        // Assert
        _ = await Assert.That(ReferenceEquals(result, options)).IsFalse();
        _ = await Assert.That(ReferenceEquals(result.Deflate, value)).IsTrue();
        _ = await Assert.That(ReferenceEquals(options.Deflate, value)).IsFalse();
        _ = await Assert.That(result.Type).IsEqualTo(options.Type);
        _ = await Assert.That(ReferenceEquals(result.Brotli, options.Brotli)).IsTrue();
        _ = await Assert.That(ReferenceEquals(result.GZip, options.GZip)).IsTrue();
    }
}