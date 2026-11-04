namespace MooVC.Serialization.Configuration.OptionsTests;

using Serializer = MooVC.Serialization.Json.Serializer;

public sealed class WhenWithTypeIsCalled
{
    [Test]
    public async Task GivenADifferentTypeThenANewOptionsInstanceRetainsOtherSettings()
    {
        // Arrange
        const string expected = "Custom";
        var original = new Options();

        // Act
        Options result = original.WithType(expected);

        // Assert
        _ = await Assert.That(ReferenceEquals(result, original)).IsFalse();
        _ = await Assert.That((string)result.Type).IsEqualTo(expected);
        _ = await Assert.That(result.Json).IsSameReferenceAs(original.Json);
        _ = await Assert.That(original.Type).IsEqualTo(Serializer.Json);
    }
}