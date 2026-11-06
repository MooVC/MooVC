namespace MooVC.Infrastructure.Serialization.Bson.Newtonsoft.SerializerTests.FactoryTests;

using Serializer = MooVC.Infrastructure.Serialization.Bson.Newtonsoft.Serializer;

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