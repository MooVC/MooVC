namespace MooVC.Linq.EnumerableExtensionsTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using static System.String;

public sealed class WhenProcessAllAsyncIsCalled
{
    [Fact]
    public async Task GivenANullSourceWhenAnEnumerableResultTransformIsProvidedThenAnEmptySetOfResultsIsReturnedAsync()
    {
        // Arrange
        IEnumerable<int>? source = default;

        static Task<IEnumerable<int>> Transform(int value)
        {
            return Task.FromResult(new[] { value }.AsEnumerable());
        }

        // Act
        IEnumerable<int> results = await source.ProcessAllAsync(Transform);

        // Assert
        _ = results.Should().BeEmpty();
    }

    [Fact]
    public async Task GivenANullSourceWhenATransformIsProvidedThenAnEmptySetOfResultsIsReturnedAsync()
    {
        // Arrange
        IEnumerable<int>? source = default;

        static Task<int> Transform(int value)
        {
            return Task.FromResult(value);
        }

        // Act
        IEnumerable<int> results = await source.ProcessAllAsync(Transform);

        // Assert
        _ = results.Should().BeEmpty();
    }

    [Fact]
    public async Task GivenANullSourceWhenNoEnumerableResultTransformIsProvidedThenNoArgumentNullExceptionIsThrownAsync()
    {
        // Arrange
        IEnumerable<int>? source = default;
        Func<int, Task<IEnumerable<int>>>? transform = default;

        // Act
        IEnumerable<int> results = await source.ProcessAllAsync(transform!);

        // Assert
        _ = results.Should().BeEmpty();
    }

    [Fact]
    public async Task GivenANullSourceWhenNoTransformIsProvidedThenNoArgumentNullExceptionIsThrownAsync()
    {
        // Arrange
        IEnumerable<int>? source = default;
        Func<int, Task<int>>? transform = default;

        // Act
        IEnumerable<int> results = await source.ProcessAllAsync(transform!);

        // Assert
        _ = results.Should().BeEmpty();
    }

    [Fact]
    public async Task GivenASourceWhenAnEnumerableResultTransformIsProvidedThenResultsForThatSourceAreReturnedAsync()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };
        IEnumerable<int> expected = new[] { 1, 4, 9 };

        static Task<IEnumerable<int>> Transform(int value)
        {
            return Task.FromResult(new[] { value * value }.AsEnumerable());
        }

        // Act
        IEnumerable<int> results = await source.ProcessAllAsync(Transform);

        // Assert
        _ = results.Should().Equal(expected);
    }

    [Fact]
    public async Task GivenASourceWhenAnEnumerableResultTransformIsProvidedThenTheSetOfResultsIsOrderedAsReturnedAsync()
    {
        // Arrange
        IEnumerable<int> source = new[] { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55 };
        IEnumerable<int> expected = Enumerable.Range(0, 60);

        static Task<IEnumerable<int>> Transform(int value)
        {
            return Task.FromResult(Enumerable.Range(value, 5));
        }

        // Act
        IEnumerable<int> actual = await source.ProcessAllAsync(Transform);

        // Assert
        _ = actual.Should().Equal(expected);
    }

    [Fact]
    public async Task GivenASourceWhenATransformIsProvidedThenResultsForThatSourceAreReturnedAsync()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };
        IEnumerable<int> expected = new[] { 1, 4, 9 };

        static Task<int> Transform(int value)
        {
            return Task.FromResult(value * value);
        }

        // Act
        IEnumerable<int> results = await source.ProcessAllAsync(Transform);

        // Assert
        _ = results.Should().Equal(expected);
    }

    [Fact]
    public async Task GivenASourceWhenATransformIsProvidedThenTheSetOfResultsIsOrderedAsReturnedAsync()
    {
        // Arrange
        const int Maximum = 60;
        IEnumerable<int> source = Enumerable.Range(0, Maximum + 1);
        IEnumerable<int> expected = source.Reverse();

        static Task<int> Transform(int value)
        {
            return Task.FromResult(Maximum - value);
        }

        // Act
        IEnumerable<int> actual = await source.ProcessAllAsync(Transform);

        // Assert
        _ = actual.Should().Equal(expected);
    }

    [Fact]
    public async Task GivenASourceWhenNoEnumerableResultTransformIsProvidedThenAnArgumentExceptionIsThrownAsync()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };
        Func<int, Task<IEnumerable<int>>>? transform = default;

        // Act
        Func<Task> act = () => source.ProcessAllAsync(transform!);

        // Assert
        _ = await act.Should().ThrowAsync<ArgumentNullException>()
            .Where(e => e.ParamName == nameof(transform));
    }

    [Fact]
    public async Task GivenASourceWhenNoTransformIsProvidedThenAnArgumentExceptionIsThrownAsync()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };
        Func<int, Task<int>>? transform = default;

        // Act
        Func<Task> act = () => source.ProcessAllAsync(transform!);

        // Assert
        _ = await act.Should().ThrowAsync<ArgumentNullException>()
            .Where(e => e.ParamName == nameof(transform));
    }

    [Fact]
    public async Task GivenALargeSourceWhenATransformIsProvidedThenResultsForThatSourceAreReturnedAsync()
    {
        // Arrange
        IEnumerable<int> source = Enumerable.Range(1, 10000);
        IEnumerable<int> expected = source.Select(x => x * x);

        static Task<int> Transform(int value)
        {
            return Task.FromResult(value * value);
        }

        // Act
        IEnumerable<int> results = await source.ProcessAllAsync(Transform);

        // Assert
        _ = results.Should().Equal(expected);
    }

    [Fact]
    public async Task GivenASourceWhenATransformThatThrowsIsProvidedThenExceptionIsPropagatedAsync()
    {
        // Arrange
        IEnumerable<int> source = new[] { 1, 2, 3 };
        Func<int, Task<int>> transform = _ => throw new InvalidOperationException();

        // Act
        Func<Task> act = () => source.ProcessAllAsync(transform);

        // Assert
        _ = await act.Should().ThrowAsync<InvalidOperationException>();
    }

    [Fact]
    public async Task GivenASourceWithComplexObjectsWhenATransformIsProvidedThenResultsForThatSourceAreReturnedAsync()
    {
        // Arrange
        IEnumerable<ComplexObject> source = new[]
        {
            new ComplexObject { Id = 1, Value = "First" },
            new ComplexObject { Id = 2, Value = "Second" },
            new ComplexObject { Id = 3, Value = "Third" },
        };

        IEnumerable<ComplexObject> expected = new[]
        {
            new ComplexObject { Id = 1, Value = "FirstFirst" },
            new ComplexObject { Id = 2, Value = "SecondSecond" },
            new ComplexObject { Id = 3, Value = "ThirdThird" },
        };

        static Task<ComplexObject> Transform(ComplexObject value)
        {
            return Task.FromResult(new ComplexObject { Id = value.Id, Value = value.Value + value.Value });
        }

        // Act
        IEnumerable<ComplexObject> results = await source.ProcessAllAsync(Transform);

        // Assert
        _ = results.Should().BeEquivalentTo(expected);
    }

    private sealed class ComplexObject
    {
        public int Id { get; set; }

        public string Value { get; set; } = Empty;
    }
}