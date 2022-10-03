namespace MooVC.Compression.DeflateCompressorTests;

using System;
using System.IO.Compression;
using Xunit;

public sealed class WhenDeflateCompressorIsConstructed
{
    [Fact]
    public void GivenNoLevelThenAnInstanceIsCreated()
    {
        _ = new DeflateCompressor();
    }

    [Theory]
    [InlineData(CompressionLevel.Optimal)]
    [InlineData(CompressionLevel.Fastest)]
    [InlineData(CompressionLevel.NoCompression)]
    [InlineData(CompressionLevel.SmallestSize)]
    public void GivenAValidLevelThenAnInstanceIsCreated(CompressionLevel level)
    {
        _ = new DeflateCompressor(level: level);
    }

    [Theory]
    [InlineData((CompressionLevel)9)]
    [InlineData((CompressionLevel)27)]
    public void GivenAnInvalidValidLevelThenAnArgumentExceptionIsThrown(CompressionLevel level)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(() => new DeflateCompressor(level: level));

        Assert.Equal(nameof(level), exception.ParamName);
    }
}