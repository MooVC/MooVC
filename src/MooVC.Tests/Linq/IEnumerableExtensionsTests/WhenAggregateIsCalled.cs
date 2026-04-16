namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenAggregateIsCalled
{
    [Test]
    public async Task GivenAListThenResultsMatchingEachKeyAreReturned()
    {
        // Arrange
        IEnumerable<int> items = [1, 2, 3];
        IDictionary<int, string> source = items.ToDictionary(item => item, item => item.ToString());

        // Act
        IEnumerable<string> results = items.Aggregate(source);

        // Assert
        _ = await Assert.That(results).IsEquivalentTo(source.Values);
    }

    [Test]
    public async Task GivenAListWhenSomeValuesAreNotPresentThenResultsForMatchingKeysAreReturned()
    {
        // Arrange
        var items = new List<int> { 1, 2, 3 };
        IDictionary<int, string> source = items.ToDictionary(item => item, item => item.ToString());

        _ = items.Remove(2);
        items.Add(4);

        IEnumerable<string> expected = ["1", "3"];

        // Act
        IEnumerable<string> results = items.Aggregate(source);

        // Assert
        _ = await Assert.That(results).IsEquivalentTo(expected);
    }

    [Test]
    public async Task GivenAnNullListAndANullSourceThenAnEmptyListOfResultsIsReturned()
    {
        // Arrange
        IEnumerable<int>? items = default;

        // Act
        IEnumerable<string> results = items.Aggregate<int, string>(default);

        // Assert
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenAnNullListThenAnEmptyListOfResultsIsReturned()
    {
        // Arrange
        IEnumerable<int>? items = default;

        // Act
        IEnumerable<string> results = items.Aggregate(new Dictionary<int, string>());

        // Assert
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenAnNullSourceThenAnEmptyListOfResultsIsReturned()
    {
        // Arrange
        IEnumerable<int> items = [1, 2, 3];

        // Act
        IEnumerable<string> results = items.Aggregate<int, string>(default);

        // Assert
        _ = await Assert.That(results).IsEmpty();
    }
}