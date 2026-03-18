namespace MooVC.Serialization.ClonerTests;

public sealed class WhenClonerIsConstructed
{
    [Test]
    public async Task GivenASerializerThenAnInstanceIsReturned()
    {
        // Arrange
        ISerializer serializer = Substitute.For<ISerializer>();

        // Act
        var cloner = new Cloner(serializer);

        // Assert
        _ = await Assert.That(cloner).IsNotNull();
    }

    [Test]
    public async Task GivenNoSerializerThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        ISerializer? serializer = default;

        // Act
        Func<ICloner> act = () => new Cloner(serializer!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(serializer));
    }
}