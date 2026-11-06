namespace MooVC.Serialization.Configuration.OptionsTests;

using System.Text.Json;

public sealed class WhenEqualsIsCalled
{
    [Test]
    public async Task GivenEquivalentOptionsThenTheyHaveEqualValuesAndHashCodes()
    {
        // Arrange
        var first = new Options();
        var second = new Options();

        // Act
        bool result = first.Equals(second);

        // Assert
        _ = await Assert.That(result).IsTrue();
        _ = await Assert.That(first.GetHashCode()).IsEqualTo(second.GetHashCode());
    }

    [Test]
    public async Task GivenDifferentTypesThenTheOptionsAreNotEqual()
    {
        // Arrange
        const string type = "Other";
        var first = new Options();
        var second = new Options { Type = type };

        // Act
        bool result = first.Equals(second);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentJsonSettingsThenTheOptionsAreNotEqual()
    {
        // Arrange
        var first = new Options();
        var second = new Options { Json = new JsonSerializerOptions { WriteIndented = true } };

        // Act
        bool result = first.Equals(second);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}