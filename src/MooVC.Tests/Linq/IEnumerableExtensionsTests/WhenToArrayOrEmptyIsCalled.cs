namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenToArrayOrEmptyIsCalled
{
    [Test]
    public async Task GivenANullEnumerableWhenAnOrderIsProvidedThenAnEmptyArrayIsReturned()
    {
        // Arrange
        IEnumerable<string>? enumerable = default;

        // Act
        string[] result = enumerable.ToArrayOrEmpty(element => element);

        // Assert
        _ = await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenANullEnumerableWhenNoOrderIsProvidedThenAnEmptyArrayIsReturned()
    {
        // Arrange
        IEnumerable<string>? enumerable = default;

        // Act
        string[] result = enumerable.ToArrayOrEmpty();

        // Assert
        _ = await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenAnEmptyEnumerableAndAPredicateWhenNoOrderIsProvidedThenAnEmptyArrayIsReturned()
    {
        // Arrange
        IEnumerable<int> enumerable = [];

        // Act
        int[] result = enumerable.ToArrayOrEmpty(predicate: value => value > 0);

        // Assert
        _ = await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenAnEmptyEnumerableWhenAnOrderIsProvidedThenAnEmptyArrayIsReturned()
    {
        // Arrange
        IEnumerable<int> enumerable = [];

        // Act
        int[] result = enumerable.ToArrayOrEmpty(element => element);

        // Assert
        _ = await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenAnEnumerableAndAPredicateWhenAnOrderIsProvidedThenAnArrayMatchingTheOrderIsReturned()
    {
        // Arrange
        IEnumerable<int> enumerable = [3, 1, 2, 4];

        // Act
        int[] result = enumerable.ToArrayOrEmpty(element => element, predicate: value => value % 2 != 0);

        // Assert
        _ = await Assert.That(result).IsEqualTo([1, 3]);
    }

    [Test]
    public async Task GivenAnEnumerableAndAPredicateWhenNoOrderIsProvidedThenAMatchingArrayIsReturned()
    {
        // Arrange
        IEnumerable<int> enumerable = [3, 1, 2, 4];

        // Act
        int[] result = enumerable.ToArrayOrEmpty(predicate: value => value % 2 != 0);

        // Assert
        _ = await Assert.That(result).IsEqualTo([3, 1]);
    }

    [Test]
    public async Task GivenAnEnumerableWhenANullOrderIsProvidedThenAnArgumentExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int> enumerable = [1];
        Func<int, int>? order = default;

        // Act
        Action act = () => enumerable.ToArrayOrEmpty(order!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(order));
    }

    [Test]
    public async Task GivenAnEnumerableWhenAnOrderIsProvidedThenAnArrayMatchingTheOrderIsReturned()
    {
        // Arrange
        IEnumerable<int> enumerable = [3, 1, 2, 0, -1];

        // Act
        int[] result = enumerable.ToArrayOrEmpty(element => element);

        // Assert
        _ = await Assert.That(result).IsEqualTo([-1, 0, 1, 2, 3]);
    }

    [Test]
    public async Task GivenAnEnumerableWhenAPredicateReturnsFalseThenEmptyArrayIsReturned()
    {
        // Arrange
        IEnumerable<int> enumerable = [1, 2, 3];

        // Act
        int[] result = enumerable.ToArrayOrEmpty(predicate: value => false);

        // Assert
        _ = await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenAnEnumerableWhenNoOrderIsProvidedThenAMatchingArrayIsReturned()
    {
        // Arrange
        IEnumerable<int> enumerable = [3, 1, 2, 0, -1];

        // Act
        int[] result = enumerable.ToArrayOrEmpty();

        // Assert
        _ = await Assert.That(result).IsEqualTo([3, 1, 2, 0, -1]);
    }
}