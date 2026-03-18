#if NET6_0_OR_GREATER
namespace MooVC.Compression.BrotliCompressorTests;

using System.ComponentModel;
using System.IO.Compression;

public sealed class WhenBrotliCompressorIsConstructed
{
    [Test]
    public void GivenNoLevelThenAnInstanceIsCreated()
    {
        // Act
        Func<ICompressor> act = () => new BrotliCompressor();

        // Assert
        _ = Should.NotThrow(act);
    }

    [Test]
    [Arguments(CompressionLevel.Optimal)]
    [Arguments(CompressionLevel.Fastest)]
    [Arguments(CompressionLevel.NoCompression)]
    [Arguments(CompressionLevel.SmallestSize)]
    public void GivenAValidLevelThenAnInstanceIsCreated(CompressionLevel level)
    {
        // Act
        Func<ICompressor> act = () => new BrotliCompressor(level: level);

        // Assert
        _ = Should.NotThrow(act);
    }

    [Test]
    [Arguments((CompressionLevel)9)]
    [Arguments((CompressionLevel)27)]
    public void GivenAnInvalidValidLevelThenAnInvalidEnumArgumentExceptionIsThrown(CompressionLevel level)
    {
        // Act
        Func<ICompressor> act = () => new BrotliCompressor(level: level);

        // Assert
        _ = Should.Throw<InvalidEnumArgumentException>(act);
    }
}
#endif