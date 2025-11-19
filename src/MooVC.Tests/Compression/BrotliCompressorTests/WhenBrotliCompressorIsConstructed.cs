#if NET6_0_OR_GREATER
namespace MooVC.Compression.BrotliCompressorTests;

using System.ComponentModel;
using System.IO.Compression;

public sealed class WhenBrotliCompressorIsConstructed
{
    [Fact]
    public void GivenNoLevelThenAnInstanceIsCreated()
    {
        // Act
        Func<ICompressor> act = () => new BrotliCompressor();

        // Assert
        _ = Should.NotThrow(act);
    }

    [Theory]
    [InlineData(CompressionLevel.Optimal)]
    [InlineData(CompressionLevel.Fastest)]
    [InlineData(CompressionLevel.NoCompression)]
    [InlineData(CompressionLevel.SmallestSize)]
    public void GivenAValidLevelThenAnInstanceIsCreated(CompressionLevel level)
    {
        // Act
        Func<ICompressor> act = () => new BrotliCompressor(level: level);

        // Assert
        _ = Should.NotThrow(act);
    }

    [Theory]
    [InlineData((CompressionLevel)9)]
    [InlineData((CompressionLevel)27)]
    public void GivenAnInvalidValidLevelThenAnInvalidEnumArgumentExceptionIsThrown(CompressionLevel level)
    {
        // Act
        Func<ICompressor> act = () => new BrotliCompressor(level: level);

        // Assert
        _ = Should.Throw<InvalidEnumArgumentException>(act);
    }
}
#endif