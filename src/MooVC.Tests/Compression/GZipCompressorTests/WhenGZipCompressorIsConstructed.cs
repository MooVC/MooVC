namespace MooVC.Compression.GZipCompressorTests;

using System;
using System.IO.Compression;
using FluentAssertions;
using Xunit;

public sealed class WhenGZipCompressorIsConstructed
{
    [Fact]
    public void GivenNoLevelThenAnInstanceIsCreated()
    {
        // Act
        Func<ICompressor> act = () => new GZipCompressor();

        // Assert
        _ = act.Should().NotThrow();
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
        _ = act.Should().NotThrow();
    }

    [Theory]
    [InlineData((CompressionLevel)9)]
    [InlineData((CompressionLevel)27)]
    public void GivenAnInvalidValidLevelThenAnArgumentExceptionIsThrown(CompressionLevel level)
    {
        // Act
        Func<ICompressor> act = () => new GZipCompressor(level: level);

        // Assert
        _ = act.Should().Throw<ArgumentException>()
            .And.ParamName.Should().Be(nameof(level));
    }
}