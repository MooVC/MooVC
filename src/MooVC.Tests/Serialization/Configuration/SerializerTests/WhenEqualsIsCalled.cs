namespace MooVC.Serialization.Configuration.SerializerTests;

using System.Text.Json;
using Compression = MooVC.Compression.Configuration.Options;

public sealed class WhenEqualsIsCalled
{
    [Test]
    public async Task GivenEquivalentOptionsThenTheyHaveEqualValuesAndHashCodes()
    {
        // Arrange
        var first = new Serializer<JsonSerializerOptions>();
        var second = new Serializer<JsonSerializerOptions>();

        // Act
        bool result = first.Equals(second);

        // Assert
        _ = await Assert.That(result).IsTrue();
        _ = await Assert.That(first.GetHashCode()).IsEqualTo(second.GetHashCode());
    }

    [Test]
    public async Task GivenDifferentCompressionThenTheOptionsAreNotEqual()
    {
        // Arrange
        const string type = "GZip";
        var first = new Serializer<JsonSerializerOptions>();
        var second = new Serializer<JsonSerializerOptions> { Compression = new Compression { Type = type } };

        // Act
        bool result = first.Equals(second);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentSettingsThenTheOptionsAreNotEqual()
    {
        // Arrange
        var first = new Serializer<JsonSerializerOptions>();
        var second = new Serializer<JsonSerializerOptions> { Settings = new JsonSerializerOptions { WriteIndented = true } };

        // Act
        bool result = first.Equals(second);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}