namespace MooVC.Infrastructure.Serialization.Bson.Newtonsoft.SerializerTests;

using global::Newtonsoft.Json;

public sealed class WhenSerializeIsCalled
{
    [Fact]
    public async Task GivenANullInstanceThenAJsonWriterExceptionIsThrown()
    {
        // Arrange
        SerializableClass? instance = default;
        var serializer = new Serializer();

        // Act
        Func<Task> action = async () => await serializer.Serialize(instance!, CancellationToken.None);

        // Assert
        JsonWriterException exception = await action.ShouldThrowAsync<JsonWriterException>();
        exception.Message.ShouldContain("BSON must start with an Object or Array.");
    }

    [Fact]
    public async Task GivenANullInstanceWhenSerializedToAStreamThenAJsonWriterExceptionIsThrown()
    {
        // Arrange
        SerializableClass? instance = default;
        using var stream = new MemoryStream();
        var serializer = new Serializer();

        // Act
        Func<Task> action = async () => await serializer.Serialize(instance!, stream, CancellationToken.None);

        // Assert
        JsonWriterException exception = await action.ShouldThrowAsync<JsonWriterException>();
        exception.Message.ShouldContain("BSON must start with an Object or Array.");
    }
}