namespace MooVC.Compression.DeflateCompressorTests;

using System.ComponentModel;
using System.IO.Compression;

public sealed class WhenDeflateCompressorIsConstructed
{
    [Test]
    public async Task GivenNoLevelThenAnInstanceIsCreated()
    {
        // Act
        Func<ICompressor> act = () => new DeflateCompressor();

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
        Func<ICompressor> act = () => new DeflateCompressor(level: level);

        // Assert
        _ = await Assert.That(act).ThrowsNothing();
    }

    [Test]
    [Arguments((CompressionLevel)9)]
    [Arguments((CompressionLevel)27)]
    public async Task GivenAnInvalidValidLevelThenAnInvalidEnumArgumentExceptionIsThrown(CompressionLevel level)
    {
        // Act
        Func<ICompressor> act = () => new DeflateCompressor(level: level);

        // Assert
        await Assert.That(act).Throws<InvalidEnumArgumentException>();
    }
}