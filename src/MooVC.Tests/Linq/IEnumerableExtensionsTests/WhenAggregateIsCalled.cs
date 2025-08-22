namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenAggregateIsCalled
{
    [Fact]
    public void GivenAnNullListAndANullSourceThenAnEmptyListOfResultsIsReturned()
    {
        // Arrange
        IEnumerable<int>? items = default;

        // Act
        IEnumerable<string> results = items.Aggregate<int, string>(default);

        // Assert
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenAnNullListThenAnEmptyListOfResultsIsReturned()
    {
        // Arrange
        IEnumerable<int>? items = default;

        // Act
        IEnumerable<string> results = items.Aggregate(new Dictionary<int, string>());

        // Assert
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenAnNullSourceThenAnEmptyListOfResultsIsReturned()
    {
        // Arrange
        IEnumerable<int> items = [1, 2, 3];

        // Act
        IEnumerable<string> results = items.Aggregate<int, string>(default);

        // Assert
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenAListThenResultsMatchingEachKeyAreReturned()
    {
        // Arrange
        IEnumerable<int> items = [1, 2, 3];
        IDictionary<int, string> source = items.ToDictionary(item => item, item => item.ToString());

        // Act
        IEnumerable<string> results = items.Aggregate(source);

        // Assert
        results.ShouldBe(source.Values);
    }

    [Fact]
    public void GivenAListWhenSomeValuesAreNotPresentThenResultsForMatchingKeysAreReturned()
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
        results.ShouldBe(expected);
    }
}