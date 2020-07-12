namespace MooVC.Collections.Generic.EnumerableExtensionsTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public sealed class WhenProcessAllIsCalled
    {
        [Fact]
        public void GivenASourceThenResultsForThatSourceAreReturned()
        {
            IEnumerable<int> source = new[] { 1, 2, 3 };
            IEnumerable<int> expected = new[] { 1, 4, 9 };
            IEnumerable<int> results = source.ProcessAll(value => value * value);

            Assert.NotNull(results);
            Assert.Contains(results, element => expected.Contains(element));
            Assert.Equal(expected.Count(), results.Count());
        }

        [Fact]
        public void GivenASourceAndAnEnumerableResultTransformThenResultsForThatSourceAreReturned()
        {
            IEnumerable<int> source = new[] { 1, 2, 3 };
            IEnumerable<int> expected = new[] { 1, 4, 9 };
            IEnumerable<int> results = source.ProcessAll(value => new[] { value * value }.AsEnumerable());

            Assert.NotNull(results);
            Assert.Contains(results, element => expected.Contains(element));
            Assert.Equal(expected.Count(), results.Count());
        }

        [Fact]
        public void GivenANullSourceThenAnEmptySetOfResultsIsReturned()
        {
            IEnumerable<int> source = null;
            IEnumerable<int> results = source.ProcessAll(value => value);

            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public void GivenANullSourceAndAnEnumerableResultTransformThenAnEmptySetOfResultsIsReturned()
        {
            IEnumerable<int> source = null;
            IEnumerable<int> results = source.ProcessAll(value => new[] { value }.AsEnumerable());

            Assert.NotNull(results);
            Assert.Empty(results);
        }
    }
}