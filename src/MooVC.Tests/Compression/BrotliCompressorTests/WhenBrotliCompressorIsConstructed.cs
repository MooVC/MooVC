#if NET6_0_OR_GREATER
namespace MooVC.Compression.BrotliCompressorTests;

using System;
using System.IO.Compression;
using FluentAssertions;
using Xunit;

public sealed class WhenBrotliCompressorIsConstructed
{
    [Fact]
    public void GivenNoLevelThenAnInstanceIsCreated()
    {
        // Act
        Func<ICompressor> act = () => new BrotliCompressor();

        // Assert
        _ = act.Should().NotThrow();
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
        _ = act.Should().NotThrow();
    }

    [Theory]
    [InlineData((CompressionLevel)9)]
    [InlineData((CompressionLevel)27)]
    public void GivenAnInvalidValidLevelThenAnArgumentExceptionIsThrown(CompressionLevel level)
    {
        // Act
        Func<ICompressor> act = () => new BrotliCompressor(level: level);

        // Assert
        _ = act.Should().Throw<ArgumentException>()
            .And.ParamName.Should().Be(nameof(level));
    }
}
#endif