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
        AssertEqual(Serializer.DefaultBufferSize, Serializer.DefaultEncoding, serializer, settings);
    }

    [Test]
    public async Task GivenABufferSizeThenASerializerIsCreatedWithTheBufferSizeApplied()
    {
        // Arrange & Act
        const int BufferSize = 32;
        var serializer = new Serializer(bufferSize: 32);
        var settings = new JsonSerializerSettings();

        // Assert
        AssertEqual(BufferSize, Serializer.DefaultEncoding, serializer, settings);
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
        AssertEqual(Serializer.MinimumBufferSize, Serializer.DefaultEncoding, serializer, settings);
    }

    [Test]
    public async Task GivenAEncodingThenASerializerIsCreatedWithTheEncodingApplied()
    {
        // Arrange & Act
        Encoding encoding = Encoding.ASCII;
        var serializer = new Serializer(encoding: encoding);
        var settings = new JsonSerializerSettings();

        // Assert
        AssertEqual(Serializer.DefaultBufferSize, encoding, serializer, settings);
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
        AssertEqual(Serializer.DefaultBufferSize, Serializer.DefaultEncoding, serializer, settings);
    }

    private static void AssertEqual(int bufferSize, Encoding encoding, Serializer serializer, JsonSerializerSettings settings)
    {
        await Assert.That(serializer.BufferSize).IsEqualTo(bufferSize);
        await Assert.That(serializer.Encoding).IsEqualTo(encoding);
        await Assert.That(serializer.Json.DateTimeZoneHandling).IsEqualTo(settings.DateTimeZoneHandling);

        AssertEqual(settings, serializer);
    }

    private static void AssertEqual(JsonSerializerSettings expected, Serializer serializer)
    {
        await Assert.That(serializer.Json.DefaultValueHandling).IsEqualTo(expected.DefaultValueHandling);
        await Assert.That(serializer.Json.NullValueHandling).IsEqualTo(expected.NullValueHandling);
        await Assert.That(serializer.Json.ReferenceLoopHandling).IsEqualTo(expected.ReferenceLoopHandling);
        await Assert.That(serializer.Json.TypeNameHandling).IsEqualTo(expected.TypeNameHandling);
        await Assert.That(serializer.Json.TypeNameAssemblyFormatHandling).IsEqualTo(expected.TypeNameAssemblyFormatHandling);
    }
}