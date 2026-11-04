namespace MooVC.Serialization.Json.SerializerTests.FactoryTests;

using Serializer = MooVC.Serialization.Json.Serializer;

public sealed class WhenFactoryIsConstructed
{
    [Test]
    public async Task GivenNullCompressorsThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        Action act = () => _ = new Serializer.Factory(null!);

        // Act
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();

        // Assert
        _ = await Assert.That(exception.ParamName).IsEqualTo("compressors");
    }
}