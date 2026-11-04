namespace MooVC.Serialization.Json.SerializerTests;

using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Text.Json;
using MooVC.Compression;
using Serializer = MooVC.Serialization.Json.Serializer;

public sealed class WhenSerializerIsConstructed
{
    private static readonly JsonSerializerOptions CamelCaseIndentedOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
    };

    private static readonly JsonSerializerOptions CamelCaseOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    private static readonly JsonSerializerOptions CaseInsensitiveOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

    [Test]
    public async Task GivenNoOptionsThenDefaultJsonConventionsAreUsed()
    {
        // Arrange
        const string Value = "Default conventions";
        var original = new TestClass { Property = Value };
        var serializer = new Serializer();
        string expected = JsonSerializer.Serialize(original);

        // Act
        byte[] serialized = (await serializer.Serialize(original, CancellationToken.None)).ToArray();

        // Assert
        _ = await Assert.That(Encoding.UTF8.GetString(serialized)).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenCustomOptionsThenSerializationUsesTheSpecifiedConventions()
    {
        // Arrange
        const string Value = "Custom conventions";
        var original = new TestClass { Property = Value };
        var serializer = new Serializer(options: CamelCaseIndentedOptions);
        string expected = JsonSerializer.Serialize(original, CamelCaseIndentedOptions);

        // Act
        byte[] serialized = (await serializer.Serialize(original, CancellationToken.None)).ToArray();

        // Assert
        _ = await Assert.That(Encoding.UTF8.GetString(serialized)).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenCaseInsensitiveOptionsThenDeserializationUsesTheSpecifiedConventions()
    {
        // Arrange
        const string Json = "{\"property\":\"Case insensitive\"}";
        const string Value = "Case insensitive";
        var serializer = new Serializer(options: CaseInsensitiveOptions);
        byte[] serialized = Encoding.UTF8.GetBytes(Json);

        // Act
        TestClass result = await serializer.Deserialize<TestClass>(serialized, CancellationToken.None);

        // Assert
        _ = await Assert.That(result.Property).IsEqualTo(Value);
    }

    [Test]
    public async Task GivenPositionalOptionsThenTheOriginalSignatureUsesThemForSerializationAndDeserialization()
    {
        // Arrange
        const string Value = "Positional options";
        var original = new TestClass { Property = Value };
        var serializer = new Serializer(CamelCaseIndentedOptions);
        string expected = JsonSerializer.Serialize(original, CamelCaseIndentedOptions);

        // Act
        byte[] serialized = (await serializer.Serialize(original, CancellationToken.None)).ToArray();
        TestClass result = await serializer.Deserialize<TestClass>(serialized, CancellationToken.None);

        // Assert
        _ = await Assert.That(Encoding.UTF8.GetString(serialized)).IsEqualTo(expected);
        _ = await Assert.That(result.Property).IsEqualTo(Value);
    }

    [Test]
    public async Task GivenPositionalNullThenTheOriginalSignatureUsesDefaultJsonConventions()
    {
        // Arrange
        const string Value = "Positional null options";
        var original = new TestClass { Property = Value };
        var serializer = new Serializer(null);
        string expected = JsonSerializer.Serialize(original);

        // Act
        byte[] serialized = (await serializer.Serialize(original, CancellationToken.None)).ToArray();
        TestClass result = await serializer.Deserialize<TestClass>(serialized, CancellationToken.None);

        // Assert
        _ = await Assert.That(Encoding.UTF8.GetString(serialized)).IsEqualTo(expected);
        _ = await Assert.That(result.Property).IsEqualTo(Value);
    }

    [Test]
    public async Task GivenTheOriginalSignatureThenThePublicConstructorRetainsItsOptionalNullDefault()
    {
        // Arrange
        const string ParameterName = "options";

        // Act
        ConstructorInfo? constructor = typeof(Serializer).GetConstructor([typeof(JsonSerializerOptions)]);

        // Assert
        _ = await Assert.That(constructor).IsNotNull();
        ParameterInfo parameter = constructor!.GetParameters().Single();
        _ = await Assert.That(parameter.Name).IsEqualTo(ParameterName);
        _ = await Assert.That(parameter.IsOptional).IsTrue();
        _ = await Assert.That(parameter.HasDefaultValue).IsTrue();
        _ = await Assert.That(parameter.DefaultValue).IsNull();
    }

    [Test]
    public async Task GivenOptionsAndCompressorThenCompressedDataUsesTheSpecifiedConventions()
    {
        // Arrange
        const string Value = "Compressed custom conventions";
        var original = new TestClass { Property = Value };
        var compressor = new GZipCompressor(new StreamCompressor.Options());
        var serializer = new Serializer(compressor: compressor, options: CamelCaseOptions);
        string expected = JsonSerializer.Serialize(original, CamelCaseOptions);

        // Act
        byte[] serialized = (await serializer.Serialize(original, CancellationToken.None)).ToArray();
        TestClass result = await serializer.Deserialize<TestClass>(serialized, CancellationToken.None);
        using var source = new MemoryStream(serialized);
        using var decompressor = new GZipStream(source, CompressionMode.Decompress);
        using var reader = new StreamReader(decompressor);
        string json = await reader.ReadToEndAsync();

        // Assert
        _ = await Assert.That(json).IsEqualTo(expected);
        _ = await Assert.That(result.Property).IsEqualTo(Value);
    }
}