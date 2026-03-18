namespace MooVC.Linq.IEnumerableExtensionsTests;

using System.Collections.Immutable;

public sealed class WhenToArrayOrEmptyIsCalled
{
    public static IEnumerable<Func<(IEnumerable<int> Original, IEnumerable<int> Expected)>> EnumerablePredicateOrderTestData()
    {
        yield return () => ([3, 1, 2], [1, 3]);
        yield return () => ([3, 2, 1], [1, 3]);
        yield return () => ([1], [1]);
        yield return () => ([], []);
    }

    public static IEnumerable<Func<(IEnumerable<int> Original, IEnumerable<int> Expected)>> EnumerableOrderTestData()
    {
        yield return () => ([3, 1, 2], [1, 2, 3]);
        yield return () => ([3, 2, 1], [1, 2, 3]);
        yield return () => ([1], [1]);
        yield return () => ([], []);
    }

    public static IEnumerable<Func<IEnumerable<int>>> EnumerableTestData()
    {
        yield return () => [1, 2];
        yield return () => [1];
        yield return () => [];
    }

    public static IEnumerable<Func<(IEnumerable<int> Original, IEnumerable<int> Expected)>> EnumerablePredicateTestData()
    {
        yield return () => ([3, 1, 2], [3, 1]);
        yield return () => ([1, 2, 3], [1, 3]);
        yield return () => ([1], [1]);
        yield return () => ([], []);
    }

    [Test]
    [MethodDataSource(nameof(EnumerableOrderTestData))]
    public async Task GivenAnEnumerableWhenAnOrderIsProvidedThenAnArrayMatchingTheOrderIsReturned(IEnumerable<int> original, IEnumerable<int> expected)
    {
        // Act
        IEnumerable<int> result = original.ToArrayOrEmpty(element => element);

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    [MethodDataSource(nameof(EnumerablePredicateOrderTestData))]
    public async Task GivenAnEnumerableAndAPredicateWhenAnOrderIsProvidedThenAnArrayMatchingTheOrderIsReturned(
        IEnumerable<int> original,
        IEnumerable<int> expected)
    {
        // Act
        IEnumerable<int> result = original.ToArrayOrEmpty(element => element, predicate: value => value != 2);

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
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
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(order));
    }

    [Test]
    [MethodDataSource(nameof(EnumerableTestData))]
    public async Task GivenAnEnumerableWhenNoOrderIsProvidedThenAMatchingArrayIsReturned(IEnumerable<int> enumerable)
    {
        // Arrange
        IEnumerable<int> expected = [.. enumerable];

        // Act
        IEnumerable<int> result = enumerable.ToArrayOrEmpty();

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    [MethodDataSource(nameof(EnumerablePredicateTestData))]
    public async Task GivenAnEnumerableAndAPredicateWhenNoOrderIsProvidedThenAMatchingArrayIsReturned(IEnumerable<int> original, IEnumerable<int> expected)
    {
        // Act
        IEnumerable<int> result = original.ToArrayOrEmpty(predicate: value => value != 2);

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

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
    public async Task GivenAnEnumerableWhenAPredicateReturnsFalseThenEmptyArrayIsReturned()
    {
        // Arrange
        IEnumerable<int> enumerable = [1, 2, 3];

        // Act
        IEnumerable<int> result = enumerable.ToArrayOrEmpty(predicate: value => false);

        // Assert
        _ = await Assert.That(result).IsEmpty();
    }
}