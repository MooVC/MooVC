namespace MooVC.Serialization.Configuration.SerializerTests;

using System.Text.Json;

public sealed class WhenWithSettingsIsCalled
{
    [Test]
    public async Task GivenSettingsThenANewOptionsInstanceRetainsCompression()
    {
        // Arrange
        var original = new Serializer<JsonSerializerOptions>();
        var settings = new JsonSerializerOptions { WriteIndented = true };

        // Act
        Serializer<JsonSerializerOptions> result = original.WithSettings(settings);

        // Assert
        _ = await Assert.That(ReferenceEquals(result, original)).IsFalse();
        _ = await Assert.That(result.Settings).IsSameReferenceAs(settings);
        _ = await Assert.That(result.Compression).IsSameReferenceAs(original.Compression);
        _ = await Assert.That(original.Settings).IsNull();
    }
}