namespace MooVC.Serialization.Configuration.SerializerTests;

using System.Text.Json;
using Compression = MooVC.Compression.Configuration.Options;

public sealed class WhenWithCompressionIsCalled
{
    [Test]
    public async Task GivenCompressionThenANewOptionsInstanceRetainsSettings()
    {
        // Arrange
        const string expectedType = "GZip";
        var settings = new JsonSerializerOptions { WriteIndented = true };
        var original = new Serializer<JsonSerializerOptions> { Settings = settings };
        var compression = new Compression { Type = expectedType };

        // Act
        Serializer<JsonSerializerOptions> result = original.WithCompression(compression);

        // Assert
        _ = await Assert.That(ReferenceEquals(result, original)).IsFalse();
        _ = await Assert.That(result.Compression).IsSameReferenceAs(compression);
        _ = await Assert.That(result.Settings).IsSameReferenceAs(settings);
        _ = await Assert.That((string)original.Compression.Type).IsEqualTo("None");
    }
}