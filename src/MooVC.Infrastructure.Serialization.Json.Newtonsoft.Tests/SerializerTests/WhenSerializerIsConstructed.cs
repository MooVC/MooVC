namespace MooVC.Infrastructure.Serialization.Json.Newtonsoft.SerializerTests;

using System.Text;
using global::Newtonsoft.Json;

public sealed class WhenSerializerIsConstructed
{
    [Test]
    public async Task GivenNoSettingsThenADefaultSerializerIsCreated()
    {
        // Arrange & Act
        var serializer = new Serializer();
        var settings = new JsonSerializerSettings();

        // Assert
        await AssertEqual(Serializer.DefaultBufferSize, Serializer.DefaultEncoding, serializer, settings);
    }

    [Test]
    public async Task GivenABufferSizeThenASerializerIsCreatedWithTheBufferSizeApplied()
    {
        // Arrange & Act
        const int BufferSize = 32;
        var serializer = new Serializer(bufferSize: 32);
        var settings = new JsonSerializerSettings();

        // Assert
        await AssertEqual(BufferSize, Serializer.DefaultEncoding, serializer, settings);
    }

    [Test]
    [Arguments(0)]
    [Arguments(-1)]
    [Arguments(1)]
    public async Task GivenABelowMinimumBufferSizeThenASerializerIsCreatedWithTheMinimumBufferSizeApplied(int bufferSize)
    {
        // Arrange & Act
        var serializer = new Serializer(bufferSize: bufferSize);
        var settings = new JsonSerializerSettings();

        // Assert
        await AssertEqual(Serializer.MinimumBufferSize, Serializer.DefaultEncoding, serializer, settings);
    }

    [Test]
    public async Task GivenAEncodingThenASerializerIsCreatedWithTheEncodingApplied()
    {
        // Arrange & Act
        Encoding encoding = Encoding.ASCII;
        var serializer = new Serializer(encoding: encoding);
        var settings = new JsonSerializerSettings();

        // Assert
        await AssertEqual(Serializer.DefaultBufferSize, encoding, serializer, settings);
    }

    [Test]
    public async Task GivenSettingsThenASerializerIsCreatedWithTheSettingsApplied()
    {
        // Arrange & Act
        var settings = new JsonSerializerSettings
        {
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            TypeNameHandling = TypeNameHandling.All,
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
        };

        var serializer = new Serializer(settings: settings);

        // Assert
        await AssertEqual(Serializer.DefaultBufferSize, Serializer.DefaultEncoding, serializer, settings);
    }

    private static async Task AssertEqual(int bufferSize, Encoding encoding, Serializer serializer, JsonSerializerSettings settings)
    {
        _ = await Assert.That(serializer.BufferSize).IsEqualTo(bufferSize);
        _ = await Assert.That(serializer.Encoding).IsEqualTo(encoding);
        _ = await Assert.That(serializer.Json.DateTimeZoneHandling).IsEqualTo(settings.DateTimeZoneHandling);

        await AssertEqual(settings, serializer);
    }

    private static async Task AssertEqual(JsonSerializerSettings expected, Serializer serializer)
    {
        _ = await Assert.That(serializer.Json.DefaultValueHandling).IsEqualTo(expected.DefaultValueHandling);
        _ = await Assert.That(serializer.Json.NullValueHandling).IsEqualTo(expected.NullValueHandling);
        _ = await Assert.That(serializer.Json.ReferenceLoopHandling).IsEqualTo(expected.ReferenceLoopHandling);
        _ = await Assert.That(serializer.Json.TypeNameHandling).IsEqualTo(expected.TypeNameHandling);
        _ = await Assert.That(serializer.Json.TypeNameAssemblyFormatHandling).IsEqualTo(expected.TypeNameAssemblyFormatHandling);
    }
}