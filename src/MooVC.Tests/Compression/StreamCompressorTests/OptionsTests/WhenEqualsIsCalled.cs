namespace MooVC.Compression.StreamCompressorTests.OptionsTests;

using System.IO.Compression;

public sealed class WhenEqualsIsCalled
{
    [Test]
    [Arguments(1, CompressionLevel.Optimal, false)]
    [Arguments(StreamCompressor.Options.DefaultBufferSize, CompressionLevel.Fastest, false)]
    [Arguments(StreamCompressor.Options.DefaultBufferSize, CompressionLevel.Optimal, true)]
    public async Task GivenOptionsThenAllSettingsDetermineEquality(int bufferSize, CompressionLevel level, bool expected)
    {
        // Arrange
        var options = new StreamCompressor.Options();
        var other = new StreamCompressor.Options { BufferSize = bufferSize, Level = level };

        // Act
        bool result = options.Equals(other);

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
        _ = await Assert.That(options == other).IsEqualTo(expected);
        _ = await Assert.That(options != other).IsEqualTo(!expected);
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        var options = new StreamCompressor.Options();

        // Act
        bool result = options.Equals(default(StreamCompressor.Options));

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}