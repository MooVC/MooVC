namespace MooVC.Infrastructure.Serialization.Json.Newtonsoft.SerializerTests;

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
        AssertEqual(Serializer.DefaultBufferSize, Serializer.DefaultEncoding, serializer, settings);
    }

    [Fact]
    public void GivenABufferSizeThenASerializerIsCreatedWithTheBufferSizeApplied()
    {
        // Arrange & Act
        const int BufferSize = 32;
        var serializer = new Serializer(bufferSize: 32);
        var settings = new JsonSerializerSettings();

        // Assert
        AssertEqual(BufferSize, Serializer.DefaultEncoding, serializer, settings);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(1)]
    public void GivenABelowMinimumBufferSizeThenASerializerIsCreatedWithTheMinimumBufferSizeApplied(int bufferSize)
    {
        // Arrange & Act
        var serializer = new Serializer(bufferSize: bufferSize);
        var settings = new JsonSerializerSettings();

        // Assert
        AssertEqual(Serializer.MinimumBufferSize, Serializer.DefaultEncoding, serializer, settings);
    }

    [Fact]
    public void GivenAEncodingThenASerializerIsCreatedWithTheEncodingApplied()
    {
        // Arrange & Act
        Encoding encoding = Encoding.ASCII;
        var serializer = new Serializer(encoding: encoding);
        var settings = new JsonSerializerSettings();

        // Assert
        AssertEqual(Serializer.DefaultBufferSize, encoding, serializer, settings);
    }

    [Fact]
    public void GivenSettingsThenASerializerIsCreatedWithTheSettingsApplied()
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
        serializer.BufferSize.ShouldBe(bufferSize);
        serializer.Encoding.ShouldBe(encoding);
        serializer.Json.DateTimeZoneHandling.ShouldBe(settings.DateTimeZoneHandling);

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