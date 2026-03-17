namespace MooVC.Compression.GZipCompressorTests;

using System.ComponentModel;
using System.IO.Compression;

public sealed class WhenGZipCompressorIsConstructed
{
    [Test]
    public void GivenNoLevelThenAnInstanceIsCreated()
    {
        // Act
        Func<ICompressor> act = () => new GZipCompressor();

        // Assert
        _ = Should.NotThrow(act);
    }

    [Test]
    [Arguments(CompressionLevel.Optimal)]
    [Arguments(CompressionLevel.Fastest)]
    [Arguments(CompressionLevel.NoCompression)]
    public void GivenAValidLevelThenAnInstanceIsCreated(CompressionLevel level)
    {
        // Act
        Func<ICompressor> act = () => new GZipCompressor(level: level);

        // Assert
        _ = Should.NotThrow(act);
    }

    [Test]
    [Arguments((CompressionLevel)9)]
    [Arguments((CompressionLevel)27)]
    public void GivenAnInvalidValidLevelThenAnInvalidEnumArgumentExceptionIsThrown(CompressionLevel level)
    {
        // Act
        Func<ICompressor> act = () => new GZipCompressor(level: level);

        // Assert
        _ = Should.Throw<InvalidEnumArgumentException>(act);
    }
}