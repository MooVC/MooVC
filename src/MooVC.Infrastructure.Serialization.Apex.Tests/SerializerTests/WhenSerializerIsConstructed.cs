namespace MooVC.Infrastructure.Serialization.Apex.SerializerTests;

using global::Apex.Serialization;

public sealed class WhenSerializerIsConstructed
{
    [Test]
    public async Task GivenNoSettingsThenADefaultSerializerIsCreated()
    {
        // Arrange & Act
        using var serializer = new Serializer();

        // Assert
        _ = await Assert.That(serializer).IsNotNull();
    }

    [Test]
    public async Task GivenSettingsThenASerializerIsCreatedWithTheSettingsApplied()
    {
        // Arrange
        var settings = new Settings
        {
            AllowFunctionSerialization = false,
            FlattenClassHierarchy = true,
            InliningMaxDepth = 4,
            SerializationMode = Mode.Graph,
            SupportSerializationHooks = true,
            UseSerializedVersionId = true,
        };

        // Act
        using var serializer = new Serializer(settings: settings);

        // Assert
        _ = await Assert.That(serializer).IsNotNull();
    }
}