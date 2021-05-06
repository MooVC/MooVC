namespace MooVC.Collections.Generic.EnumerableExtensionsTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public sealed class WhenAggregateIsCalled
    {
        [Fact]
        public void GivenAnNullListAndANullSourceThenAnEmptyListOfResultsIsReturned()
        {
            IEnumerable<int>? items = default;
            IEnumerable<string> results = items.Aggregate<int, string>(default);

            Assert.Empty(results);
        }

        [Fact]
        public void GivenAnNullListThenAnEmptyListOfResultsIsReturned()
        {
            IEnumerable<int>? items = default;
            IEnumerable<string> results = items.Aggregate(new Dictionary<int, string>());

            Assert.Empty(results);
        }

        [Fact]
        public void GivenAnNullSourceThenAnEmptyListOfResultsIsReturned()
        {
            IEnumerable<int> items = new[] { 1, 2, 3 };
            IEnumerable<string> results = items.Aggregate<int, string>(default);

            Assert.Empty(results);
        }

        [Fact]
        public void GivenAListThenResultsMatchingEachKeyAreReturned()
        {
            IEnumerable<int> items = new[] { 1, 2, 3 };
            IDictionary<int, string> source = items.ToDictionary(item => item, item => item.ToString());
            IEnumerable<string> results = items.Aggregate(source);

            Assert.Equal(source.Values, results);
        }

        [Fact]
        public void GivenAListWhenSomeValuesAreNotPresentThenResultsForMatchingKeysAreReturned()
        {
            var items = new List<int> { 1, 2, 3 };
            IDictionary<int, string> source = items.ToDictionary(item => item, item => item.ToString());

            _ = items.Remove(2);
            items.Add(4);

            IEnumerable<string> expected = new[] { "1", "3" };
            IEnumerable<string> results = items.Aggregate(source);

            Assert.Equal(expected, results);
        }
    }
}