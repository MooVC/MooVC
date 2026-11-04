namespace MooVC.Composition.InstanceFactoryTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenNullStrategiesThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerable<IInstanceStrategy<object, int>> strategies = null!;

        // Act
        Func<InstanceFactory<object, int>> act = () => new InstanceFactory<object, int>(strategies);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(strategies));
    }

    [Test]
    public async Task GivenNoStrategiesThenAnInstanceIsCreated()
    {
        // Act
        var factory = new InstanceFactory<object, int>([]);

        // Assert
        _ = await Assert.That(factory).IsNotNull();
    }
}