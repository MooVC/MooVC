namespace MooVC.Infrastructure.Serialization.Bson.Newtonsoft.SerializerTests;

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
        AssertEqual(Serializer.DefaultEncoding, DateTimeKind.Unspecified, serializer, settings);
    }

    [Test]
    public async Task GivenAEncodingThenASerializerIsCreatedWithTheEncodingApplied()
    {
        // Arrange & Act
        Encoding encoding = Encoding.ASCII;
        var serializer = new Serializer(encoding: encoding);
        var settings = new JsonSerializerSettings();

        // Assert
        AssertEqual(encoding, DateTimeKind.Unspecified, serializer, settings);
    }

    [Test]
    [Arguments(DateTimeKind.Utc)]
    [Arguments(DateTimeKind.Local)]
    public async Task GivenAKindThenASerializerIsCreatedWithTheKindApplied(DateTimeKind kind)
    {
        // Arrange & Act
        var serializer = new Serializer(kind: kind);
        var settings = new JsonSerializerSettings();

        // Assert
        AssertEqual(Serializer.DefaultEncoding, kind, serializer, settings);
    }

    [Test]
    public async Task GivenSettingsThenASerializerIsCreatedWithTheSettingsApplied()
    {
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

        AssertEqual(
            Serializer.DefaultEncoding,
            DateTimeKind.Unspecified,
            serializer,
            settings);
    }

    private static void AssertEqual(Encoding encoding, DateTimeKind kind, Serializer serializer, JsonSerializerSettings settings)
    {
        _ = await Assert.That(serializer.Encoding).IsEqualTo(encoding);
        _ = await Assert.That(serializer.Kind).IsEqualTo(kind);
        _ = await Assert.That(serializer.Json.DateFormatHandling).IsEqualTo(settings.DateFormatHandling);

        AssertEqual(settings, serializer);
    }

    private static void AssertEqual(JsonSerializerSettings expected, Serializer serializer)
    {
        _ = await Assert.That(serializer.Json.DefaultValueHandling).IsEqualTo(expected.DefaultValueHandling);
        _ = await Assert.That(serializer.Json.NullValueHandling).IsEqualTo(expected.NullValueHandling);
        _ = await Assert.That(serializer.Json.ReferenceLoopHandling).IsEqualTo(expected.ReferenceLoopHandling);
        _ = await Assert.That(serializer.Json.TypeNameHandling).IsEqualTo(expected.TypeNameHandling);
        _ = await Assert.That(serializer.Json.TypeNameAssemblyFormatHandling).IsEqualTo(expected.TypeNameAssemblyFormatHandling);
    }
}