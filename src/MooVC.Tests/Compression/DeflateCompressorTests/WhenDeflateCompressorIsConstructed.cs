namespace MooVC.Compression.DeflateCompressorTests;

using System.ComponentModel;
using System.IO.Compression;

public sealed class WhenDeflateCompressorIsConstructed
{
    [Test]
    public void GivenNoLevelThenAnInstanceIsCreated()
    {
        // Act
        Func<ICompressor> act = () => new DeflateCompressor();

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
        Func<ICompressor> act = () => new DeflateCompressor(level: level);

        // Assert
        _ = Should.NotThrow(act);
    }

    [Test]
    [Arguments((CompressionLevel)9)]
    [Arguments((CompressionLevel)27)]
    public void GivenAnInvalidValidLevelThenAnInvalidEnumArgumentExceptionIsThrown(CompressionLevel level)
    {
        // Act
        Func<ICompressor> act = () => new DeflateCompressor(level: level);

        // Assert
        _ = Should.Throw<InvalidEnumArgumentException>(act);
    }
}