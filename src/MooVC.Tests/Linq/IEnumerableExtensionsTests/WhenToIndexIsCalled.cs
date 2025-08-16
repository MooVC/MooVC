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
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(act);
        exception.ParamName.ShouldBe(nameof(selector));
    }

    [Fact]
    public void GivenANullSourceThenAnEmptyDictionaryIsReturned()
    {
        // Arrange
        IEnumerable<int>? source = default;

        // Act
        IDictionary<int, int> index = source.ToIndex(value => value);

        // Assert
        index.ShouldNotBeNull();
        index.ShouldBeEmpty();
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
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(act);
        exception.ParamName.ShouldBe(nameof(transform));
    }

    [Fact]
    public void GivenASourceThenAMatchingDictionaryIsReturned()
    {
        // Arrange
        IEnumerable<int> source = [1, 2, 3];

        // Act
        IDictionary<int, int> index = source.ToIndex(value => value);

        // Assert
        index.ShouldNotBeNull();
        index.Keys.ShouldBe(source);
        index.Values.ShouldBe(source);
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
        index.ShouldNotBeNull();
        index.Keys.ShouldBe(source);
        index.All(element => element.Value == transform(element.Key)).ShouldBeTrue();
    }

    [Fact]
    public void GivenASourceWithDuplicatesThenAnArgumentExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int> source = [1, 1, 2];

        // Act
        Action act = () => source.ToIndex(value => value);

        // Assert
        Should.Throw<ArgumentException>(act);
    }
}