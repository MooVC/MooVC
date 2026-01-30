namespace MooVC.Compression.DeflateCompressorTests;

using System.ComponentModel;
using System.IO.Compression;

public sealed class WhenDeflateCompressorIsConstructed
{
    [Fact]
    public void GivenNoLevelThenAnInstanceIsCreated()
    {
        // Act
        Func<ICompressor> act = () => new DeflateCompressor();

        // Assert
        _ = Should.NotThrow(act);
    }

    [Theory]
    [InlineData(CompressionLevel.Optimal)]
    [InlineData(CompressionLevel.Fastest)]
    [InlineData(CompressionLevel.NoCompression)]
    public void GivenAValidLevelThenAnInstanceIsCreated(CompressionLevel level)
    {
        // Act
        Func<ICompressor> act = () => new DeflateCompressor(level: level);

        // Assert
        _ = Should.NotThrow(act);
    }

    [Theory]
    [InlineData((CompressionLevel)9)]
    [InlineData((CompressionLevel)27)]
    public void GivenAnInvalidValidLevelThenAnInvalidEnumArgumentExceptionIsThrown(CompressionLevel level)
    {
        // Act
        Func<ICompressor> act = () => new DeflateCompressor(level: level);

        // Assert
        _ = Should.Throw<InvalidEnumArgumentException>(act);
    }
}