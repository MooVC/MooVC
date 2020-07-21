namespace MooVC.Collections.Generic.EnumerableExtensionsTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public sealed class WhenProcessIsCalled
    {
        [Fact]
        public void GivenASourceThenResultsForThatSourceAreReturned()
        {
            IEnumerable<int> source = new[] { 1, 2, 3 };
            IEnumerable<int> expected = new[] { 1, 4, 9 };
            IEnumerable<int> results = source.Process(value => value * value);

            Assert.NotNull(results);
            Assert.Equal(expected, results);
        }

        [Fact]
        public void GivenASourceAndAnEnumerableResultTransformThenResultsForThatSourceAreReturned()
        {
            IEnumerable<int> source = new[] { 1, 2, 3 };
            IEnumerable<int> expected = new[] { 1, 4, 9 };
            IEnumerable<int> results = source.Process(value => new[] { value * value }.AsEnumerable());

            Assert.NotNull(results);
            Assert.Equal(expected, results);
        }

        [Fact]
        public void GivenANullSourceThenAnEmptySetOfResultsIsReturned()
        {
            IEnumerable<int> source = null;
            IEnumerable<int> results = source.Process(value => value);

            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public void GivenANullSourceAndAnEnumerableResultTransformThenAnEmptySetOfResultsIsReturned()
        {
            IEnumerable<int> source = null;
            IEnumerable<int> results = source.Process(value => new[] { value }.AsEnumerable());

            Assert.NotNull(results);
            Assert.Empty(results);
        }
    }
}