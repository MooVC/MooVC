namespace MooVC.Compression.GZipCompressorTests;

using System.ComponentModel;
using System.IO.Compression;

public sealed class WhenGZipCompressorIsConstructed
{
    [Fact]
    public void GivenNoLevelThenAnInstanceIsCreated()
    {
        // Act
        Func<ICompressor> act = () => new GZipCompressor();

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
        Func<ICompressor> act = () => new GZipCompressor(level: level);

        // Assert
        _ = Should.NotThrow(act);
    }

    [Theory]
    [InlineData((CompressionLevel)9)]
    [InlineData((CompressionLevel)27)]
    public void GivenAnInvalidValidLevelThenAnInvalidEnumArgumentExceptionIsThrown(CompressionLevel level)
    {
        // Act
        Func<ICompressor> act = () => new GZipCompressor(level: level);

        // Assert
        _ = Should.Throw<InvalidEnumArgumentException>(act);
    }
}