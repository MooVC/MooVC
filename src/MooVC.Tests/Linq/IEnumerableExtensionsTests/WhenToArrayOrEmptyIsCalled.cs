namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenToArrayOrEmptyIsCalled
{
    public static IEnumerable<object?[]> EnumerableOrderTestData()
    {
        yield return [new[] { 3, 1, 2 }, new[] { 1, 2, 3 }];
        yield return [new[] { 3, 2, 1 }, new[] { 1, 2, 3 }];
        yield return [new[] { 1 }, new[] { 1 }];
        yield return [Array.Empty<int>(), Array.Empty<int>()];
    }

    public static IEnumerable<(int[] Original, int[] Expected)> EnumerablePredicateOrderTestData()
    {
        yield return (new int[] { 3, 1, 2 }, new int[] { 1, 3 });
        yield return (new int[] { 3, 2, 1 }, new int[] { 1, 3 });
        yield return (new int[] { 1 }, new int[] { 1 });
        yield return (Array.Empty<int>(), Array.Empty<int>());
    }

    public static IEnumerable<int[]> EnumerableTestData()
    {
        yield return new int[] { 1, 2 };
        yield return new int[] { 1 };
        yield return Array.Empty<int>();
    }

    public static IEnumerable<object?[]> EnumerablePredicateTestData()
    {
        yield return [new[] { 3, 1, 2 }, new[] { 3, 1 }];
        yield return [new[] { 1, 2, 3 }, new[] { 1, 3 }];
        yield return [new[] { 1 }, new[] { 1 }];
        yield return [Array.Empty<int>(), Array.Empty<int>()];
    }

    [Test]
    [MethodDataSource(nameof(EnumerableOrderTestData))]
    public async Task GivenAnEnumerableWhenAnOrderIsProvidedThenAnArrayMatchingTheOrderIsReturned(int[] original, int[] expected)
    {
        // Arrange
        IEnumerable<int> enumerable = original;

        // Act
        IEnumerable<int> result = enumerable.ToArrayOrEmpty(element => element);

        // Assert
        _ = await Assert.That(result).IsEquivalentTo(expected);
    }

    [Test]
    [MethodDataSource(nameof(EnumerablePredicateOrderTestData))]
    public async Task GivenAnEnumerableAndAPredicateWhenAnOrderIsProvidedThenAnArrayMatchingTheOrderIsReturned(int[] original, int[] expected)
    {
        // Arrange
        IEnumerable<int> enumerable = original;

        // Act
        IEnumerable<int> result = enumerable.ToArrayOrEmpty(element => element, predicate: value => value != 2);

        // Assert
        _ = await Assert.That(result).IsEquivalentTo(expected);
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
    [MethodDataSource(nameof(EnumerableTestData))]
    public async Task GivenAnEnumerableWhenNoOrderIsProvidedThenAMatchingArrayIsReturned(int[] source)
    {
        // Arrange
        IEnumerable<int> enumerable = source;
        IEnumerable<int> expected = [.. enumerable];

        // Act
        IEnumerable<int> result = enumerable.ToArrayOrEmpty();

        // Assert
        _ = await Assert.That(result).IsEquivalentTo(expected);
    }

    [Test]
    [MethodDataSource(nameof(EnumerablePredicateTestData))]
    public async Task GivenAnEnumerableAndAPredicateWhenNoOrderIsProvidedThenAMatchingArrayIsReturned(int[] original, int[] expected)
    {
        // Arrange
        IEnumerable<int> enumerable = original;

        // Act
        IEnumerable<int> result = enumerable.ToArrayOrEmpty(predicate: value => value != 2);

        // Assert
        _ = await Assert.That(result).IsEquivalentTo(expected);
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