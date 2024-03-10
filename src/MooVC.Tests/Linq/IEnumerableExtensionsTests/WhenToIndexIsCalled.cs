namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenToIndexIsCalled
{
    [Fact]
    public void GivenANullSelectorThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        Func<int, string>? selector = default;
        IEnumerable<int> source = [1, 2, 3];

        // Act
        Action act = () => source.ToIndex(selector!);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
           .WithParameterName(nameof(selector));
    }

    [Fact]
    public void GivenANullSourceThenAnEmptyDictionaryIsReturned()
    {
        // Arrange
        IEnumerable<int>? source = default;

        // Act
        IDictionary<int, int> index = source.ToIndex(value => value);

        // Assert
        _ = index.Should().NotBeNull()
            .And.BeEmpty();
    }

    [Fact]
    public void GivenANullTransformThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        Func<int, string>? transform = default;
        IEnumerable<int> source = [1, 2, 3];

        // Act
        Action act = () => source.ToIndex(value => value, transform!);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
           .WithParameterName(nameof(transform));
    }

    [Fact]
    public void GivenASourceThenAMatchingDictionaryIsReturned()
    {
        // Arrange
        IEnumerable<int> source = [1, 2, 3];

        // Act
        IDictionary<int, int> index = source.ToIndex(value => value);

        // Assert
        _ = index.Should().NotBeNull();
        _ = index.Keys.Should().Equal(source);
        _ = index.Values.Should().Equal(source);
    }

    [Fact]
    public void GivenASourceAndATransformThenAMatchingDictionaryIsReturned()
    {
        // Arrange
        IEnumerable<int> source = [1, 2, 3];
        Func<int, string> transform = value => value.ToString();

        // Act
        IDictionary<int, string> index = source.ToIndex(value => value, transform);

        // Assert
        _ = index.Should().NotBeNull();
        _ = index.Keys.Should().Equal(source);
        _ = index.All(element => element.Value == transform(element.Key)).Should().BeTrue();
    }

    [Fact]
    public void GivenASourceWithDuplicatesThenAnArgumentExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int> source = [1, 1, 2];

        // Act
        Action act = () => source.ToIndex(value => value);

        // Assert
        _ = act.Should().Throw<ArgumentException>();
    }
}