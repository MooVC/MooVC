namespace MooVC.Infrastructure.Serialization.Bson.Newtonsoft.SerializerTests;

using System.Text;
using global::Newtonsoft.Json;

public sealed class WhenSerializerIsConstructed
{
    [Fact]
    public void GivenNoSettingsThenADefaultSerializerIsCreated()
    {
        // Arrange & Act
        var serializer = new Serializer();
        var settings = new JsonSerializerSettings();

        // Assert
        AssertEqual(Serializer.DefaultEncoding, DateTimeKind.Unspecified, serializer, settings);
    }

    [Fact]
    public void GivenAEncodingThenASerializerIsCreatedWithTheEncodingApplied()
    {
        // Arrange & Act
        Encoding encoding = Encoding.ASCII;
        var serializer = new Serializer(encoding: encoding);
        var settings = new JsonSerializerSettings();

        // Assert
        AssertEqual(encoding, DateTimeKind.Unspecified, serializer, settings);
    }

    [Theory]
    [InlineData(DateTimeKind.Utc)]
    [InlineData(DateTimeKind.Local)]
    public void GivenAKindThenASerializerIsCreatedWithTheKindApplied(DateTimeKind kind)
    {
        // Arrange & Act
        var serializer = new Serializer(kind: kind);
        var settings = new JsonSerializerSettings();

        // Assert
        AssertEqual(Serializer.DefaultEncoding, kind, serializer, settings);
    }

    [Fact]
    public void GivenSettingsThenASerializerIsCreatedWithTheSettingsApplied()
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
        serializer.Encoding.ShouldBe(encoding);
        serializer.Kind.ShouldBe(kind);
        serializer.Json.DateFormatHandling.ShouldBe(settings.DateFormatHandling);

        AssertEqual(settings, serializer);
    }

    private static void AssertEqual(JsonSerializerSettings expected, Serializer serializer)
    {
        serializer.Json.DefaultValueHandling.ShouldBe(expected.DefaultValueHandling);
        serializer.Json.NullValueHandling.ShouldBe(expected.NullValueHandling);
        serializer.Json.ReferenceLoopHandling.ShouldBe(expected.ReferenceLoopHandling);
        serializer.Json.TypeNameHandling.ShouldBe(expected.TypeNameHandling);
        serializer.Json.TypeNameAssemblyFormatHandling.ShouldBe(expected.TypeNameAssemblyFormatHandling);
    }
}