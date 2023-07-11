namespace MooVC.Collections.Generic.EnumerableExtensionsTests;

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

public sealed class WhenProcessAllIsCalled
{
    [Fact]
    public void GivenANullSourceWhenAnEnumerableResultTransformIsProvidedThenAnEmptySetOfResultsIsReturned()
    {
        // Arrange
        IEnumerable<int>? source = default;

        static IEnumerable<int> Transform(int value)
        {
            return new[] { value };
        }

        // Act
        IEnumerable<int> results = source.ProcessAll(Transform);

        // Assert
        _ = results.Should().NotBeNull().And.BeEmpty();
    }

    [Fact]
    public void GivenANullSourceWhenATransformIsProvidedThenAnEmptySetOfResultsIsReturned()
    {
        // Arrange
        IEnumerable<int>? source = default;

        // Act
        IEnumerable<int> results = source.ProcessAll(value => value);

        // Assert
        _ = results.Should().NotBeNull()
            .And.BeEmpty();
    }

    [Fact]
    public void GivenANullSourceWhenNoEnumerableResultTransformIsProvidedThenNoArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int>? source = default;
        Func<int, IEnumerable<int>>? transform = default;

        // Act
        IEnumerable<int> results = source.ProcessAll(transform!);

        // Assert
        _ = results.Should().NotBeNull()
            .And.BeEmpty();
    }

    [Fact]
    public void GivenANullSourceWhenNoTransformIsProvidedThenNoArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int>? source = default;
        Func<int, int>? transform = default;

        // Act
        IEnumerable<int> results = source.ProcessAll(transform!);

        // Assert
        _ = results.Should().NotBeNull()
            .And.BeEmpty();
    }

    [Fact]
    public void GivenASourceWhenAnEnumerableResultTransformIsProvidedThenResultsForThatSourceAreReturned()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };
        IEnumerable<int> expected = new[] { 1, 4, 9 };

        static IEnumerable<int> Transform(int value)
        {
            return new[] { value * value };
        }

        // Act
        IEnumerable<int> results = source.ProcessAll(Transform);

        // Assert
        _ = results.Should().Equal(expected);
    }

    [Fact]
    public void GivenASourceWhenAnEnumerableResultTransformIsProvidedThenTheSetOfResultsIsOrderedAsReturned()
    {
        // Arrange
        IEnumerable<int> source = new[] { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55 };
        IEnumerable<int> expected = Enumerable.Range(0, 60);

        static IEnumerable<int> Transform(int value)
        {
            return Enumerable.Range(value, 5);
        }

        // Act
        IEnumerable<int> actual = source.ProcessAll(Transform);

        // Assert
        _ = actual.Should().Equal(expected);
    }

    [Fact]
    public void GivenASourceWhenATransformIsProvidedThenResultsForThatSourceAreReturned()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };
        IEnumerable<int> expected = new[] { 1, 4, 9 };

        static int Transform(int value)
        {
            return value * value;
        }

        // Act
        IEnumerable<int> results = source.ProcessAll(Transform);

        // Assert
        _ = results.Should().Equal(expected);
    }

    [Fact]
    public void GivenASourceWhenATransformIsProvidedThenTheSetOfResultsIsOrderedAsReturned()
    {
        // Arrange
        const int Maximum = 60;
        IEnumerable<int> source = Enumerable.Range(0, Maximum + 1);
        IEnumerable<int> expected = source.Reverse();

        static int Transform(int value)
        {
            return Maximum - value;
        }

        // Act
        IEnumerable<int> actual = source.ProcessAll(Transform);

        // Assert
        _ = actual.Should().Equal(expected);
    }

    [Fact]
    public void GivenASourceWhenNoEnumerableResultTransformIsProvidedThenAnArgumentExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };
        Func<int, IEnumerable<int>>? transform = default;

        // Act
        Action act = () => source.ProcessAll(transform!);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
           .And.ParamName.Should().Be(nameof(transform));
    }

    [Fact]
    public void GivenASourceWhenNoTransformIsProvidedThenAnArgumentExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };
        Func<int, int>? transform = default;

        // Act
        Action act = () => source.ProcessAll(transform!);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
           .And.ParamName.Should().Be(nameof(transform));
    }
}