namespace MooVC.Compression.Configuration.OptionsTests;

using System.IO.Compression;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenOneAlgorithmIsChangedThenOtherAlgorithmsAndInstancesKeepTheirDefaults()
    {
        // Arrange
        var options = new Options();
        var other = new Options();

        // Act
        options.Brotli.Level = CompressionLevel.Fastest;

        // Assert
        _ = await Assert.That(options.Deflate.Level).IsEqualTo(CompressionLevel.Optimal);
        _ = await Assert.That(options.GZip.Level).IsEqualTo(CompressionLevel.Optimal);
        _ = await Assert.That(other.Brotli.Level).IsEqualTo(CompressionLevel.Optimal);
    }

    [Test]
    public async Task GivenNoSettingsThenCompressionIsDisabledWithIndependentAlgorithmDefaults()
    {
        // Act
        var options = new Options();
        var other = new Options();

        // Assert
        _ = await Assert.That((string)options.Type).IsEqualTo("None");
        _ = await Assert.That(options.Brotli.BufferSize).IsEqualTo(StreamCompressor.Options.DefaultBufferSize);
        _ = await Assert.That(options.Deflate.BufferSize).IsEqualTo(StreamCompressor.Options.DefaultBufferSize);
        _ = await Assert.That(options.GZip.BufferSize).IsEqualTo(StreamCompressor.Options.DefaultBufferSize);
        _ = await Assert.That(options.Brotli.Level).IsEqualTo(CompressionLevel.Optimal);
        _ = await Assert.That(options.Deflate.Level).IsEqualTo(CompressionLevel.Optimal);
        _ = await Assert.That(options.GZip.Level).IsEqualTo(CompressionLevel.Optimal);
        _ = await Assert.That(ReferenceEquals(options.Brotli, options.Deflate)).IsFalse();
        _ = await Assert.That(ReferenceEquals(options.Deflate, options.GZip)).IsFalse();
        _ = await Assert.That(ReferenceEquals(options.Brotli, other.Brotli)).IsFalse();
        _ = await Assert.That(ReferenceEquals(options.Deflate, other.Deflate)).IsFalse();
        _ = await Assert.That(ReferenceEquals(options.GZip, other.GZip)).IsFalse();
    }
}