namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenToArrayOrEmptyIsCalled
{
    public static IEnumerable<(int[] Original, int[] Expected)> EnumerablePredicateOrderTestData()
    {
        yield return ([3, 1, 2], [1, 3]);
        yield return ([3, 2, 1], [1, 3]);
        yield return ([1], [1]);
        yield return ([], []);
    }

    public static IEnumerable<(int[] Original, int[] Expected)> EnumerableOrderTestData()
    {
        yield return ([3, 1, 2], [1, 2, 3]);
        yield return ([3, 2, 1], [1, 2, 3]);
        yield return ([1], [1]);
        yield return ([], []);
    }

    public static IEnumerable<int[]> EnumerableTestData()
    {
        yield return [1, 2];
        yield return [1];
        yield return [];
    }

    public static IEnumerable<(int[] Original, int[] Expected)> EnumerablePredicateTestData()
    {
        yield return ([3, 1, 2], [3, 1]);
        yield return ([1, 2, 3], [1, 3]);
        yield return ([1], [1]);
        yield return ([], []);
    }

    [Test]
    [MethodDataSource(nameof(EnumerableOrderTestData))]
    public void GivenAnEnumerableWhenAnOrderIsProvidedThenAnArrayMatchingTheOrderIsReturned(IEnumerable<int> original, IEnumerable<int> expected)
    {
        // Act
        int[] result = original.ToArrayOrEmpty(element => element);

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    [MethodDataSource(nameof(EnumerablePredicateOrderTestData))]
    public void GivenAnEnumerableAndAPredicateWhenAnOrderIsProvidedThenAnArrayMatchingTheOrderIsReturned(
        IEnumerable<int> original,
        IEnumerable<int> expected)
    {
        // Act
        int[] result = original.ToArrayOrEmpty(element => element, predicate: value => value != 2);

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    public void GivenAnEnumerableWhenANullOrderIsProvidedThenAnArgumentExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int> enumerable = [1];
        Func<int, int>? order = default;

        // Act
        Action act = () => enumerable.ToArrayOrEmpty(order!);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(act);
        exception.ParamName.ShouldBe(nameof(order));
    }

    [Test]
    [MethodDataSource(nameof(EnumerableTestData))]
    public void GivenAnEnumerableWhenNoOrderIsProvidedThenAMatchingArrayIsReturned(IEnumerable<int> enumerable)
    {
        // Arrange
        int[] expected = [.. enumerable];

        // Act
        int[] result = enumerable.ToArrayOrEmpty();

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    [MethodDataSource(nameof(EnumerablePredicateTestData))]
    public void GivenAnEnumerableAndAPredicateWhenNoOrderIsProvidedThenAMatchingArrayIsReturned(IEnumerable<int> original, IEnumerable<int> expected)
    {
        // Act
        int[] result = original.ToArrayOrEmpty(predicate: value => value != 2);

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    public void GivenANullEnumerableWhenAnOrderIsProvidedThenAnEmptyArrayIsReturned()
    {
        // Arrange
        IEnumerable<string>? enumerable = default;

        // Act
        string[] result = enumerable.ToArrayOrEmpty(element => element);

        // Assert
        result.ShouldBeEmpty();
    }

    [Test]
    public void GivenANullEnumerableWhenNoOrderIsProvidedThenAnEmptyArrayIsReturned()
    {
        // Arrange
        IEnumerable<string>? enumerable = default;

        // Act
        string[] result = enumerable.ToArrayOrEmpty();

        // Assert
        result.ShouldBeEmpty();
    }

    [Test]
    public void GivenAnEnumerableWhenAPredicateReturnsFalseThenEmptyArrayIsReturned()
    {
        // Arrange
        IEnumerable<int> enumerable = [1, 2, 3];

        // Act
        int[] result = enumerable.ToArrayOrEmpty(predicate: value => false);

        // Assert
        result.ShouldBe([]);
    }
}