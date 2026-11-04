namespace MooVC.Serialization.Configuration.SerializerTests;

using System.Text.Json;
using MooVC.Compression;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenNewOptionsThenCompressionIsDisabledAndSettingsAreUnset()
    {
        // Arrange
        const string expected = "None";

        // Act
        var options = new Serializer<JsonSerializerOptions>();

        // Assert
        _ = await Assert.That((string)options.Compression.Type).IsEqualTo(expected);
        _ = await Assert.That(options.Settings).IsNull();
    }

    [Test]
    public async Task GivenTwoOptionsThenTheirCompressionSettingsAreIndependent()
    {
        // Arrange
        const int expected = 128;
        var first = new Serializer<JsonSerializerOptions>();
        var second = new Serializer<JsonSerializerOptions>();

        // Act
        first.Compression.GZip.BufferSize = expected;

        // Assert
        _ = await Assert.That(ReferenceEquals(first.Compression, second.Compression)).IsFalse();
        _ = await Assert.That(first.Compression.GZip.BufferSize).IsEqualTo(expected);
        _ = await Assert.That(second.Compression.GZip.BufferSize).IsEqualTo(StreamCompressor.Options.DefaultBufferSize);
    }
}