namespace MooVC.Infrastructure.Serialization.Bson.Newtonsoft.SerializerTests;

using global::Newtonsoft.Json;

public sealed class WhenSerializeIsCalled
{
    [Test]
    public async Task GivenANullInstanceThenAJsonWriterExceptionIsThrown()
    {
        // Arrange
        SerializableClass? instance = default;
        var serializer = new Serializer();

        // Act
        Func<Task> action = async () => await serializer.Serialize(instance!, CancellationToken.None);

        // Assert
        JsonWriterException exception = await Assert.That(action).Throws<JsonWriterException>().And.IsNotNull();
        _ = await Assert.That(exception.Message).Contains("BSON must start with an Object or Array.");
    }

    [Test]
    public async Task GivenANullInstanceWhenSerializedToAStreamThenAJsonWriterExceptionIsThrown()
    {
        // Arrange
        SerializableClass? instance = default;
        using var stream = new MemoryStream();
        var serializer = new Serializer();

        // Act
        Func<Task> action = async () => await serializer.Serialize(instance!, stream, CancellationToken.None);

        // Assert
        JsonWriterException exception = await Assert.That(action).Throws<JsonWriterException>().And.IsNotNull();
        _ = await Assert.That(exception.Message).Contains("BSON must start with an Object or Array.");
    }
}