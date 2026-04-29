#if NET6_0_OR_GREATER
namespace MooVC.Compression.BrotliCompressorTests;

using System.ComponentModel;
using System.IO.Compression;

public sealed class WhenBrotliCompressorIsConstructed
{
    [Test]
    [Arguments((CompressionLevel)9)]
    [Arguments((CompressionLevel)27)]
    public async Task GivenAnInvalidValidLevelThenAnInvalidEnumArgumentExceptionIsThrown(CompressionLevel level)
    {
        // Act
        Func<ICompressor> act = () => new BrotliCompressor(level: level);

        // Assert
        _ = await Assert.That(act).Throws<InvalidEnumArgumentException>();
    }

    [Test]
    [Arguments(CompressionLevel.Optimal)]
    [Arguments(CompressionLevel.Fastest)]
    [Arguments(CompressionLevel.NoCompression)]
    [Arguments(CompressionLevel.SmallestSize)]
    public async Task GivenAValidLevelThenAnInstanceIsCreated(CompressionLevel level)
    {
        // Act
        Func<ICompressor> act = () => new BrotliCompressor(level: level);

        // Assert
        _ = await Assert.That(act).ThrowsNothing();
    }

    [Test]
    public async Task GivenNoLevelThenAnInstanceIsCreated()
    {
        // Act
        Func<ICompressor> act = () => new BrotliCompressor();

        // Assert
        _ = await Assert.That(act).ThrowsNothing();
    }
}
#endif