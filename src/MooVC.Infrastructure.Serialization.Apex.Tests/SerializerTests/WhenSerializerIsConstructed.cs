namespace MooVC.Infrastructure.Serialization.Apex.SerializerTests;

using global::Apex.Serialization;

public sealed class WhenSerializerIsConstructed
{
    [Fact]
    public void GivenNoSettingsThenADefaultSerializerIsCreated()
    {
        // Arrange & Act
        using var serializer = new Serializer();

        // Assert
        _ = serializer.Should().NotBeNull();
    }

    [Fact]
    public void GivenSettingsThenASerializerIsCreatedWithTheSettingsApplied()
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
        _ = serializer.Should().NotBeNull();
    }
}