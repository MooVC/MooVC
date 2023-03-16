namespace MooVC.Compression.BrotliCompressorTests;

using System;
using System.IO.Compression;
using Xunit;

public sealed class WhenBrotliCompressorIsConstructed
{
    [Fact]
    public void GivenNoLevelThenAnInstanceIsCreated()
    {
        _ = new BrotliCompressor();
    }

    [Theory]
    [InlineData(CompressionLevel.Optimal)]
    [InlineData(CompressionLevel.Fastest)]
    [InlineData(CompressionLevel.NoCompression)]
    [InlineData(CompressionLevel.SmallestSize)]
    public void GivenAValidLevelThenAnInstanceIsCreated(CompressionLevel level)
    {
        _ = new BrotliCompressor(level: level);
    }

    [Theory]
    [InlineData((CompressionLevel)9)]
    [InlineData((CompressionLevel)27)]
    public void GivenAnInvalidValidLevelThenAnArgumentExceptionIsThrown(CompressionLevel level)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(() => new BrotliCompressor(level: level));

        Assert.Equal(nameof(level), exception.ParamName);
    }
}