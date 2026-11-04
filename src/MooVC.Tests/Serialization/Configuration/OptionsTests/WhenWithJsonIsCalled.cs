namespace MooVC.Serialization.Configuration.OptionsTests;

using System.Text.Json;

public sealed class WhenWithJsonIsCalled
{
    [Test]
    public async Task GivenJsonSettingsThenANewOptionsInstanceRetainsTheType()
    {
        // Arrange
        var original = new Options();
        var settings = new JsonSerializerOptions { WriteIndented = true };

        // Act
        Options result = original.WithJson(settings);

        // Assert
        _ = await Assert.That(ReferenceEquals(result, original)).IsFalse();
        _ = await Assert.That(result.Json).IsSameReferenceAs(settings);
        _ = await Assert.That(result.Type).IsEqualTo(original.Type);
        _ = await Assert.That(ReferenceEquals(original.Json, settings)).IsFalse();
    }
}