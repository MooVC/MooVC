namespace MooVC.Linq.EnumerableExtensionsTests;

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

public sealed class WhenToArrayOrEmptyIsCalled
{
    public static readonly IEnumerable<object[]> EnumerablePredicateOrderTestData = new[]
    {
        new object[] { new int[] { 3, 1, 2 }, new int[] { 1, 3 } },
        new object[] { new int[] { 3, 2, 1 }, new int[] { 1, 3 } },
        new object[] { new int[] { 1 }, new int[] { 1 } },
        new object[] { Array.Empty<int>(), Array.Empty<int>() },
    };

    public static readonly IEnumerable<object[]> EnumerableOrderTestData = new[]
    {
        new object[] { new int[] { 3, 1, 2 }, new int[] { 1, 2, 3 } },
        new object[] { new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 } },
        new object[] { new int[] { 1 }, new int[] { 1 } },
        new object[] { Array.Empty<int>(), Array.Empty<int>() },
    };

    public static readonly IEnumerable<object[]> EnumerableTestData = new[]
    {
        new object[] { new int[] { 1, 2 } },
        new object[] { new int[] { 1 } },
        new object[] { Array.Empty<int>() },
    };

    public static readonly IEnumerable<object[]> EnumerablePredicateTestData = new[]
    {
        new object[] { new int[] { 3, 1, 2 }, new int[] { 3, 1 } },
        new object[] { new int[] { 1, 2, 3 }, new int[] { 1, 3 } },
        new object[] { new int[] { 1 }, new int[] { 1 } },
        new object[] { Array.Empty<int>(), Array.Empty<int>() },
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
        IEnumerable<int> enumerable = new int[] { 1 };
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
        _ = result.Should().BeEquivalentTo(Array.Empty<string>());
    }

    [Fact]
    public void GivenANullEnumerableWhenNoOrderIsProvidedThenAnEmptyArrayIsReturned()
    {
        // Arrange
        IEnumerable<string>? enumerable = default;

        // Act
        string[] result = enumerable.ToArrayOrEmpty();

        // Assert
        _ = result.Should().BeEquivalentTo(Array.Empty<string>());
    }

    [Fact]
    public void GivenAnEnumerableWhenAPredicateReturnsFalseThenEmptyArrayIsReturned()
    {
        // Arrange
        IEnumerable<int> enumerable = new int[] { 1, 2, 3 };

        // Act
        int[] result = enumerable.ToArrayOrEmpty(predicate: value => false);

        // Assert
        _ = result.Should().BeEquivalentTo(Array.Empty<int>());
    }
}