namespace MooVC.Infrastructure.Serialization.MessagePack.SerializerTests;

using global::MessagePack;

public sealed class WhenSerializerIsConstructed
{
    [Test]
    public void GivenNoOptionsConfigurationThenADefaultSerializerIsCreated()
    {
        // Arrange & Act
        var serializer = new Serializer();

        // Assert
        serializer.Options.ShouldBeEquivalentTo(MessagePackSerializerOptions.Standard);
    }

    [Test]
    public void GivenOptionsThenASerializerIsCreatedWithTheOptionsApplied()
    {
        // Arrange & Act
        MessagePackSerializerOptions options = MessagePackSerializerOptions
            .Standard
            .WithCompression(MessagePackCompression.Lz4BlockArray)
            .WithOmitAssemblyVersion(true);

        var serializer = new Serializer(options: options);

        // Assert
        serializer.Options.ShouldBeEquivalentTo(serializer.Options);
    }
}