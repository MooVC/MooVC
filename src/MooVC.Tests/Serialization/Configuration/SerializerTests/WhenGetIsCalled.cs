namespace MooVC.Serialization.Configuration.SerializerTests;

using System.Text.Json;
using Microsoft.Extensions.Configuration;
using MooVC.Compression;

public sealed class WhenGetIsCalled
{
    [Test]
    [Arguments("None")]
    [Arguments("Brotli")]
    [Arguments("Deflate")]
    [Arguments("GZip")]
    public async Task GivenACompressionTypeThenTheConfiguredTypeIsSelected(string expected)
    {
        // Arrange
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Compression:Type"] = expected,
            })
            .Build();

        // Act
        Serializer<JsonSerializerOptions>? options = configuration.Get<Serializer<JsonSerializerOptions>>();

        // Assert
        _ = await Assert.That(options).IsNotNull();
        _ = await Assert.That((string)options!.Compression.Type).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenNestedSettingsThenTheyAreBoundToTheirRespectiveOptions()
    {
        // Arrange
        const string bufferSize = "512";
        const int expectedBufferSize = 512;
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Compression:GZip:BufferSize"] = bufferSize,
                ["Settings:WriteIndented"] = bool.TrueString,
            })
            .Build();

        // Act
        Serializer<JsonSerializerOptions>? options = configuration.Get<Serializer<JsonSerializerOptions>>();

        // Assert
        _ = await Assert.That(options!.Compression.GZip.BufferSize).IsEqualTo(expectedBufferSize);
        _ = await Assert.That(options.Settings.WriteIndented).IsTrue();
        _ = await Assert.That(options.Compression.Deflate.BufferSize).IsEqualTo(StreamCompressor.Options.DefaultBufferSize);
    }
}