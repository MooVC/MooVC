namespace MooVC.Infrastructure.Serialization.MessagePack.SerializerTests;

using global::MessagePack;

public sealed class WhenSerializerIsConstructed
{
    [Test]
    public async Task GivenNoOptionsConfigurationThenADefaultSerializerIsCreated()
    {
        // Arrange & Act
        var serializer = new Serializer();

        // Assert
        _ = await Assert.That(serializer.Options).IsEquivalentTo(MessagePackSerializerOptions.Standard);
    }

    [Test]
    public async Task GivenOptionsThenASerializerIsCreatedWithTheOptionsApplied()
    {
        // Arrange & Act
        MessagePackSerializerOptions options = MessagePackSerializerOptions
            .Standard
            .WithCompression(MessagePackCompression.Lz4BlockArray)
            .WithOmitAssemblyVersion(true);

        var serializer = new Serializer(options: options);

        // Assert
        _ = await Assert.That(serializer.Options).IsEquivalentTo(serializer.Options);
    }
}