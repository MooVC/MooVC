namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenToIndexIsCalled
{
    [Test]
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

    [Test]
    public void GivenANullSourceThenAnEmptyDictionaryIsReturned()
    {
        // Arrange
        IEnumerable<int>? source = default;

        // Act
        IDictionary<int, int> index = source.ToIndex(value => value);

        // Assert
        _ = index.ShouldNotBeNull();
        index.ShouldBeEmpty();
    }

    [Test]
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

    [Test]
    public void GivenASourceThenAMatchingDictionaryIsReturned()
    {
        // Arrange
        IEnumerable<int> source = [1, 2, 3];

        // Act
        IDictionary<int, int> index = source.ToIndex(value => value);

        // Assert
        _ = index.ShouldNotBeNull();
        index.Keys.ShouldBe(source);
        index.Values.ShouldBe(source);
    }

    [Test]
    public void GivenASourceAndATransformThenAMatchingDictionaryIsReturned()
    {
        // Arrange
        IEnumerable<int> source = [1, 2, 3];
        Func<int, string> transform = value => value.ToString();

        // Act
        IDictionary<int, string> index = source.ToIndex(value => value, transform);

        // Assert
        _ = index.ShouldNotBeNull();
        index.Keys.ShouldBe(source);
        index.All(element => element.Value == transform(element.Key)).ShouldBeTrue();
    }

    [Test]
    public void GivenASourceWithDuplicatesThenAnArgumentExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int> source = [1, 1, 2];

        // Act
        Action act = () => source.ToIndex(value => value);

        // Assert
        _ = Should.Throw<ArgumentException>(act);
    }
}