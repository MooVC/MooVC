namespace MooVC.Compression.GZipCompressorTests;

using System.ComponentModel;
using System.IO.Compression;

public sealed class WhenGZipCompressorIsConstructed
{
    [Test]
    public async Task GivenNoLevelThenAnInstanceIsCreated()
    {
        // Act
        Func<ICompressor> act = () => new GZipCompressor();

        // Assert
        _ = await Assert.That(act).ThrowsNothing();
    }

    [Test]
    [Arguments(CompressionLevel.Optimal)]
    [Arguments(CompressionLevel.Fastest)]
    [Arguments(CompressionLevel.NoCompression)]
    public async Task GivenAValidLevelThenAnInstanceIsCreated(CompressionLevel level)
    {
        // Act
        Func<ICompressor> act = () => new GZipCompressor(level: level);

        // Assert
        _ = await Assert.That(act).ThrowsNothing();
    }

    [Test]
    [Arguments((CompressionLevel)9)]
    [Arguments((CompressionLevel)27)]
    public async Task GivenAnInvalidValidLevelThenAnInvalidEnumArgumentExceptionIsThrown(CompressionLevel level)
    {
        // Act
        Func<ICompressor> act = () => new GZipCompressor(level: level);

        // Assert
        _ = await Assert.That(act).Throws<InvalidEnumArgumentException>();
    }
}