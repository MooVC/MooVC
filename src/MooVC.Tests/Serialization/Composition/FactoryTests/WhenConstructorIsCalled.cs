namespace MooVC.Serialization.Composition.FactoryTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenNoCompressorsThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange & Act
        Func<TestFactory> act = () => new TestFactory(null!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo("compressors");
    }

    [Test]
    public async Task GivenNoCompressorStrategiesThenAFactoryIsCreated()
    {
        // Arrange & Act
        var factory = new TestFactory([]);

        // Assert
        _ = await Assert.That(factory.CreationCount).IsEqualTo(0);
    }
}