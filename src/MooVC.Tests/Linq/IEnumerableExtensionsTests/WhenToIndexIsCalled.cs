namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenToIndexIsCalled
{
    [Test]
    public async Task GivenANullSelectorThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        Func<int, string>? selector = default;
        IEnumerable<int> source = [1, 2, 3];

        // Act
        Action act = () => source.ToIndex(selector!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(selector));
    }

    [Test]
    public async Task GivenANullSourceThenAnEmptyDictionaryIsReturned()
    {
        // Arrange
        IEnumerable<int>? source = default;

        // Act
        IDictionary<int, int> index = source.ToIndex(value => value);

        // Assert
        _ = await Assert.That(index).IsNotNull();
        _ = await Assert.That(index).IsEmpty();
    }

    [Test]
    public async Task GivenANullTransformThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        Func<int, string>? transform = default;
        IEnumerable<int> source = [1, 2, 3];

        // Act
        Action act = () => source.ToIndex(value => value, transform!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(transform));
    }

    [Test]
    public async Task GivenASourceAndATransformThenAMatchingDictionaryIsReturned()
    {
        // Arrange
        IEnumerable<int> source = [1, 2, 3];
        Func<int, string> transform = value => value.ToString();

        // Act
        IDictionary<int, string> index = source.ToIndex(value => value, transform);

        // Assert
        _ = await Assert.That(index).IsNotNull();
        _ = await Assert.That(index.Keys).IsEquivalentTo(source);
        _ = await Assert.That(index.All(element => element.Value == transform(element.Key))).IsTrue();
    }

    [Test]
    public async Task GivenASourceThenAMatchingDictionaryIsReturned()
    {
        // Arrange
        IEnumerable<int> source = [1, 2, 3];

        // Act
        IDictionary<int, int> index = source.ToIndex(value => value);

        // Assert
        _ = await Assert.That(index).IsNotNull();
        _ = await Assert.That(index.Keys).IsEquivalentTo(source);
        _ = await Assert.That(index.Values).IsEquivalentTo(source);
    }

    [Test]
    public async Task GivenASourceWithDuplicatesThenAnArgumentExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int> source = [1, 1, 2];

        // Act
        Action act = () => source.ToIndex(value => value);

        // Assert
        _ = await Assert.That(act).Throws<ArgumentException>();
    }
}