namespace MooVC.Infrastructure.Serialization.MessagePack.SerializerTests;

using global::MessagePack;

public sealed class WhenSerializerIsConstructed
{
    [Fact]
    public void GivenNoOptionsConfigurationThenADefaultSerializerIsCreated()
    {
        // Arrange & Act
        var serializer = new Serializer();

        // Assert
        _ = serializer.Options.Should().BeEquivalentTo(MessagePackSerializerOptions.Standard);
    }

    [Fact]
    public void GivenOptionsThenASerializerIsCreatedWithTheOptionsApplied()
    {
        // Arrange & Act
        MessagePackSerializerOptions options = MessagePackSerializerOptions
            .Standard
            .WithCompression(MessagePackCompression.Lz4BlockArray)
            .WithOmitAssemblyVersion(true);

        var serializer = new Serializer(options: options);

        // Assert
        _ = serializer.Options.Should().BeEquivalentTo(serializer.Options);
    }
}