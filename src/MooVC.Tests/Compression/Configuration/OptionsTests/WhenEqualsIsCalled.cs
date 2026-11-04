namespace MooVC.Compression.Configuration.OptionsTests;

using System.IO.Compression;

public sealed class WhenEqualsIsCalled
{
    [Test]
    public async Task GivenEqualSettingsThenValuesAndHashesMatch()
    {
        // Arrange
        var options = new Options();
        var other = new Options();

        // Act
        bool result = options.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
        _ = await Assert.That(options.GetHashCode()).IsEqualTo(other.GetHashCode());
        _ = await Assert.That(options == other).IsTrue();
        _ = await Assert.That(options != other).IsFalse();
    }

    [Test]
    public async Task GivenDifferentTypeThenValuesDiffer()
    {
        // Arrange
        var options = new Options();
        var other = new Options { Type = GZipCompressor.GZip };

        // Act
        bool result = options.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    [Arguments("Brotli")]
    [Arguments("Deflate")]
    [Arguments("GZip")]
    public async Task GivenDifferentAlgorithmSettingsThenValuesDiffer(string algorithm)
    {
        // Arrange
        var options = new Options();
        var other = new Options();
        StreamCompressor.Options algorithmOptions = algorithm switch
        {
            "Brotli" => other.Brotli,
            "Deflate" => other.Deflate,
            _ => other.GZip,
        };
        algorithmOptions.Level = CompressionLevel.Fastest;

        // Act
        bool result = options.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}