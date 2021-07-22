namespace MooVC.Linq.EnumerableExtensionsTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public sealed class WhenSafeAnyIsCalled
    {
        [Fact]
        public void GivenAnEmptySourceThenANegativeResponseIsReturned()
        {
            IEnumerable<int> source = Enumerable.Empty<int>();

            Assert.False(source.SafeAny());
        }

        [Fact]
        public void GivenAnEmptySourceAndAPredicateThenANegativeResponseIsReturned()
        {
            IEnumerable<int> source = Enumerable.Empty<int>();

            Assert.False(source.SafeAny(predicate => true));
        }

        [Fact]
        public void GivenAnPopulatedSourceThenAPositiveResponseIsReturned()
        {
            IEnumerable<int> source = new int[1];

            Assert.True(source.SafeAny());
        }

        [Fact]
        public void GivenAnPopulatedSourceAndAFailingPredicateThenANegativeResponseIsReturned()
        {
            IEnumerable<int> source = new int[1];

            Assert.False(source.SafeAny(predicate => false));
        }

        [Fact]
        public void GivenAnPopulatedSourceAndAPassingPredicateThenAPositiveResponseIsReturned()
        {
            IEnumerable<int> source = new int[1];

            Assert.True(source.SafeAny(predicate => true));
        }

        [Fact]
        public void GivenANullSourceThenANegativeResponseIsReturned()
        {
            IEnumerable<int>? source = default;

            Assert.False(source.SafeAny());
        }

        [Fact]
        public void GivenANullSourceAndAPredicateThenANegativeResponseIsReturned()
        {
            IEnumerable<int>? source = default;

            Assert.False(source.SafeAny(predicate => true));
        }
    }
}