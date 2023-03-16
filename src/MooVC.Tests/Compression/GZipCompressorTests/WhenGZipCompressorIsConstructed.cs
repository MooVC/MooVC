namespace MooVC.Compression.GZipCompressorTests;

using System;
using System.IO.Compression;
using Xunit;

public sealed class WhenGZipCompressorIsConstructed
{
    [Fact]
    public void GivenNoLevelThenAnInstanceIsCreated()
    {
        _ = new GZipCompressor();
    }

    [Theory]
    [InlineData(CompressionLevel.Optimal)]
    [InlineData(CompressionLevel.Fastest)]
    [InlineData(CompressionLevel.NoCompression)]
    [InlineData(CompressionLevel.SmallestSize)]
    public void GivenAValidLevelThenAnInstanceIsCreated(CompressionLevel level)
    {
        _ = new GZipCompressor(level: level);
    }

    [Theory]
    [InlineData((CompressionLevel)9)]
    [InlineData((CompressionLevel)27)]
    public void GivenAnInvalidValidLevelThenAnArgumentExceptionIsThrown(CompressionLevel level)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(() => new GZipCompressor(level: level));

        Assert.Equal(nameof(level), exception.ParamName);
    }
}