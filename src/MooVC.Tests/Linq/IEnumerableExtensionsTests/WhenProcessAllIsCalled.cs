namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenProcessAllIsCalled
{
    [Fact]
    public void GivenANullSourceWhenAnEnumerableResultTransformIsProvidedThenAnEmptySetOfResultsIsReturned()
    {
        // Arrange
        IEnumerable<int>? source = default;

        static IEnumerable<int> Transform(int value)
        {
            return [value];
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
        IEnumerable<int> source = [1, 2, 3];
        IEnumerable<int> expected = [1, 4, 9];

        static IEnumerable<int> Transform(int value)
        {
            return [value * value];
        }

        // Act
        IEnumerable<int> results = source.ProcessAll(Transform);

        // Assert
        _ = results.Should().Equal(expected);
    }

    [Fact]
    public void GivenASourceWhenAnEnumerableResultTransformThatYieldsNullIsProvidedThenEmptyResultsForThatSourceAreReturned()
    {
        // Arrange
        IEnumerable<int> source = [1, 2, 3];
        IEnumerable<int> expected = [];

        static IEnumerable<int> Transform(int value)
        {
            return default!;
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
        IEnumerable<int> source = [0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55];
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
        IEnumerable<int> source = [1, 2, 3];
        IEnumerable<int> expected = [1, 4, 9];

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
    public void GivenASourceWhenATransformIsProvidedThatYieldsANullResultThenEmptyResultsForThatSourceAreReturned()
    {
        // Arrange
        IEnumerable<string> source = ["Hello", "World"];
        IEnumerable<string> expected = [];

        static string Transform(string value)
        {
            return default!;
        }

        // Act
        IEnumerable<string> results = source.ProcessAll(Transform);

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
        IEnumerable<int> source = [1, 2, 3];
        Func<int, IEnumerable<int>>? transform = default;

        // Act
        Action act = () => source.ProcessAll(transform!);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
           .WithParameterName(nameof(transform));
    }

    [Fact]
    public void GivenASourceWhenNoTransformIsProvidedThenAnArgumentExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int> source = [1, 2, 3];
        Func<int, int>? transform = default;

        // Act
        Action act = () => source.ProcessAll(transform!);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
           .WithParameterName(nameof(transform));
    }

    [Fact]
    public async Task GivenANullSourceWhenAnAsyncEnumerableResultTransformIsProvidedThenAnEmptySetOfResultsIsReturned()
    {
        // Arrange
        IEnumerable<int>? source = default;

        static Task<IEnumerable<int>> Transform(int value)
        {
            return Task.FromResult(Enumerable.AsEnumerable(new[] { value }));
        }

        // Act
        IEnumerable<int> results = await source.ProcessAll(Transform);

        // Assert
        _ = results.Should().BeEmpty();
    }

    [Fact]
    public async Task GivenANullSourceWhenAnAsyncTransformIsProvidedThenAnEmptySetOfResultsIsReturned()
    {
        // Arrange
        IEnumerable<int>? source = default;

        static Task<int> Transform(int value)
        {
            return Task.FromResult(value);
        }

        // Act
        IEnumerable<int> results = await source.ProcessAll(Transform);

        // Assert
        _ = results.Should().BeEmpty();
    }

    [Fact]
    public async Task GivenANullSourceWhenNoAsyncEnumerableResultTransformIsProvidedThenNoArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int>? source = default;
        Func<int, Task<IEnumerable<int>>>? transform = default;

        // Act
        IEnumerable<int> results = await source.ProcessAll(transform!);

        // Assert
        _ = results.Should().BeEmpty();
    }

    [Fact]
    public async Task GivenANullSourceWhenNoAsyncTransformIsProvidedThenNoArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int>? source = default;
        Func<int, Task<int>>? transform = default;

        // Act
        IEnumerable<int> results = await source.ProcessAll(transform!);

        // Assert
        _ = results.Should().BeEmpty();
    }

    [Fact]
    public async Task GivenASourceWhenAnAsyncEnumerableResultTransformIsProvidedThenResultsForThatSourceAreReturned()
    {
        // Arrange
        IEnumerable<int> source = [1, 2, 3];
        IEnumerable<int> expected = [1, 4, 9];

        static Task<IEnumerable<int>> Transform(int value)
        {
            return Task.FromResult(Enumerable.AsEnumerable(new[] { value * value }));
        }

        // Act
        IEnumerable<int> results = await source.ProcessAll(Transform);

        // Assert
        _ = results.Should().Equal(expected);
    }

    [Fact]
    public async Task GivenASourceWhenAnAsyncEnumerableResultTransformIsProvidedThenTheSetOfResultsIsOrderedAsReturned()
    {
        // Arrange
        IEnumerable<int> source = [0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55];
        IEnumerable<int> expected = Enumerable.Range(0, 60);

        static Task<IEnumerable<int>> Transform(int value)
        {
            return Task.FromResult(Enumerable.Range(value, 5));
        }

        // Act
        IEnumerable<int> actual = await source.ProcessAll(Transform);

        // Assert
        _ = actual.Should().Equal(expected);
    }

    [Fact]
    public async Task GivenASourceWhenAnAsyncTransformIsProvidedThenResultsForThatSourceAreReturned()
    {
        // Arrange
        IEnumerable<int> source = [1, 2, 3];
        IEnumerable<int> expected = [1, 4, 9];

        static Task<int> Transform(int value)
        {
            return Task.FromResult(value * value);
        }

        // Act
        IEnumerable<int> results = await source.ProcessAll(Transform);

        // Assert
        _ = results.Should().Equal(expected);
    }

    [Fact]
    public async Task GivenASourceWhenAnAsyncTransformIsProvidedThenTheSetOfResultsIsOrderedAsReturned()
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
        IEnumerable<int> actual = await source.ProcessAll(Transform);

        // Assert
        _ = actual.Should().Equal(expected);
    }

    [Fact]
    public async Task GivenASourceWhenNoAsyncEnumerableResultTransformIsProvidedThenAnArgumentExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int> source = [1, 2, 3];
        Func<int, Task<IEnumerable<int>>>? transform = default;

        // Act
        Func<Task> act = () => source.ProcessAll(transform!);

        // Assert
        _ = await act.Should().ThrowAsync<ArgumentNullException>()
            .Where(e => e.ParamName == nameof(transform));
    }

    [Fact]
    public async Task GivenASourceWhenNoAsyncTransformIsProvidedThenAnArgumentExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int> source = [1, 2, 3];
        Func<int, Task<int>>? transform = default;

        // Act
        Func<Task> act = () => source.ProcessAll(transform!);

        // Assert
        _ = await act.Should().ThrowAsync<ArgumentNullException>()
            .Where(e => e.ParamName == nameof(transform));
    }

    [Fact]
    public async Task GivenALargeSourceWhenATnAsyncransformIsProvidedThenResultsForThatSourceAreReturned()
    {
        // Arrange
        IEnumerable<int> source = Enumerable.Range(1, 10000);
        IEnumerable<int> expected = source.Select(x => x * x);

        static Task<int> Transform(int value)
        {
            return Task.FromResult(value * value);
        }

        // Act
        IEnumerable<int> results = await source.ProcessAll(Transform);

        // Assert
        _ = results.Should().Equal(expected);
    }

    [Fact]
    public async Task GivenASourceWhenAnAsyncTransformThatThrowsIsProvidedThenExceptionIsPropagated()
    {
        // Arrange
        IEnumerable<int> source = [1, 2, 3];
        Func<int, Task<int>> transform = _ => throw new InvalidOperationException();

        // Act
        Func<Task> act = () => source.ProcessAll(transform);

        // Assert
        _ = await act.Should().ThrowAsync<InvalidOperationException>();
    }

    [Fact]
    public async Task GivenASourceWithComplexObjectsWhenAnAsyncTransformIsProvidedThenResultsForThatSourceAreReturned()
    {
        // Arrange
        IEnumerable<ComplexObject> source =
        [
            new() { Id = 1, Value = "First" },
            new() { Id = 2, Value = "Second" },
            new() { Id = 3, Value = "Third" },
        ];

        IEnumerable<ComplexObject> expected =
        [
            new() { Id = 1, Value = "FirstFirst" },
            new() { Id = 2, Value = "SecondSecond" },
            new() { Id = 3, Value = "ThirdThird" },
        ];

        static Task<ComplexObject> Transform(ComplexObject value)
        {
            return Task.FromResult(new ComplexObject { Id = value.Id, Value = value.Value + value.Value });
        }

        // Act
        IEnumerable<ComplexObject> results = await source.ProcessAll(Transform);

        // Assert
        _ = results.Should().BeEquivalentTo(expected);
    }

    private sealed class ComplexObject
    {
        public int Id { get; set; }

        public string Value { get; set; } = string.Empty;
    }
}