namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenToArrayOrEmptyIsCalled
{
    public static readonly TheoryData<int[], int[]> EnumerablePredicateOrderTestData = new()
    {
        { [3, 1, 2], [1, 3] },
        { [3, 2, 1], [1, 3] },
        { [1], [1] },
        { [], [] },
    };

    public static readonly TheoryData<int[], int[]> EnumerableOrderTestData = new()
    {
        { [3, 1, 2], [1, 2, 3] },
        { [3, 2, 1], [1, 2, 3] },
        { [1], [1] },
        { [], [] },
    };

    public static readonly TheoryData<int[]> EnumerableTestData = new()
    {
        { [1, 2] },
        { [1] },
        { [] },
    };

    public static readonly TheoryData<int[], int[]> EnumerablePredicateTestData = new()
    {
        { [3, 1, 2], [3, 1] },
        { [1, 2, 3], [1, 3] },
        { [1], [1] },
        { [], [] },
    };

    [Theory]
    [MemberData(nameof(EnumerableOrderTestData))]
    public void GivenAnEnumerableWhenAnOrderIsProvidedThenAnArrayMatchingTheOrderIsReturned(IEnumerable<int> original, IEnumerable<int> expected)
    {
        // Act
        int[] result = original.ToArrayOrEmpty(element => element);

        // Assert
        _ = result.Should().Equal(expected);
    }

    [Theory]
    [MemberData(nameof(EnumerablePredicateOrderTestData))]
    public void GivenAnEnumerableAndAPredicateWhenAnOrderIsProvidedThenAnArrayMatchingTheOrderIsReturned(
        IEnumerable<int> original,
        IEnumerable<int> expected)
    {
        // Act
        int[] result = original.ToArrayOrEmpty(element => element, predicate: value => value != 2);

        // Assert
        _ = result.Should().Equal(expected);
    }

    [Fact]
    public void GivenAnEnumerableWhenANullOrderIsProvidedThenAnArgumentExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int> enumerable = [1];
        Func<int, int>? order = default;

        // Act
        Action act = () => enumerable.ToArrayOrEmpty(order!);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
           .WithParameterName(nameof(order));
    }

    [Theory]
    [MemberData(nameof(EnumerableTestData))]
    public void GivenAnEnumerableWhenNoOrderIsProvidedThenAMatchingArrayIsReturned(IEnumerable<int> enumerable)
    {
        // Arrange
        int[] expected = enumerable.ToArray();

        // Act
        int[] result = enumerable.ToArrayOrEmpty();

        // Assert
        _ = result.Should().Equal(expected);
    }

    [Theory]
    [MemberData(nameof(EnumerablePredicateTestData))]
    public void GivenAnEnumerableAndAPredicateWhenNoOrderIsProvidedThenAMatchingArrayIsReturned(IEnumerable<int> original, IEnumerable<int> expected)
    {
        // Act
        int[] result = original.ToArrayOrEmpty(predicate: value => value != 2);

        // Assert
        _ = result.Should().Equal(expected);
    }

    [Fact]
    public void GivenANullEnumerableWhenAnOrderIsProvidedThenAnEmptyArrayIsReturned()
    {
        // Arrange
        IEnumerable<string>? enumerable = default;

        // Act
        string[] result = enumerable.ToArrayOrEmpty(element => element);

        // Assert
        _ = result.Should().BeEquivalentTo();
    }

    [Fact]
    public void GivenANullEnumerableWhenNoOrderIsProvidedThenAnEmptyArrayIsReturned()
    {
        // Arrange
        IEnumerable<string>? enumerable = default;

        // Act
        string[] result = enumerable.ToArrayOrEmpty();

        // Assert
        _ = result.Should().BeEquivalentTo();
    }

    [Fact]
    public void GivenAnEnumerableWhenAPredicateReturnsFalseThenEmptyArrayIsReturned()
    {
        // Arrange
        IEnumerable<int> enumerable = [1, 2, 3];

        // Act
        int[] result = enumerable.ToArrayOrEmpty(predicate: value => false);

        // Assert
        _ = result.Should().BeEquivalentTo(Array.Empty<int>());
    }
}