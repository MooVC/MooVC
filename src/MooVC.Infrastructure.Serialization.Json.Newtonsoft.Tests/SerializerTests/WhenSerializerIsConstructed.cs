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
        _ = serializer.BufferSize.Should().Be(bufferSize);
        _ = serializer.Encoding.Should().Be(encoding);
        _ = serializer.Json.DateTimeZoneHandling.Should().Be(settings.DateTimeZoneHandling);

        AssertEqual(settings, serializer);
    }

    private static void AssertEqual(JsonSerializerSettings expected, Serializer serializer)
    {
        _ = serializer.Json.DefaultValueHandling.Should().Be(expected.DefaultValueHandling);
        _ = serializer.Json.NullValueHandling.Should().Be(expected.NullValueHandling);
        _ = serializer.Json.ReferenceLoopHandling.Should().Be(expected.ReferenceLoopHandling);
        _ = serializer.Json.TypeNameHandling.Should().Be(expected.TypeNameHandling);
        _ = serializer.Json.TypeNameAssemblyFormatHandling.Should().Be(expected.TypeNameAssemblyFormatHandling);
    }
}