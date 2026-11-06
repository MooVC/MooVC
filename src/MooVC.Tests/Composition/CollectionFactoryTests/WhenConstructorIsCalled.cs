namespace MooVC.Composition.CollectionFactoryTests;

using TestOptions = MooVC.Composition.CollectionFactoryTests.WhenCreateIsCalled.TestOptions;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenNullStrategiesThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerable<ICollectionStrategy<object, TestOptions, int>> strategies = null!;

        // Act
        Func<CollectionFactory<object, TestOptions, int>> act = () => new CollectionFactory<object, TestOptions, int>(strategies);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(strategies));
    }

    [Test]
    public async Task GivenNoStrategiesThenAnInstanceIsCreated()
    {
        // Act
        var factory = new CollectionFactory<object, TestOptions, int>([]);

        // Assert
        _ = await Assert.That(factory).IsNotNull();
    }
}