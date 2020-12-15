namespace MooVC.Linq.EnumerableExtensionsTests
{
    using System.Collections.Generic;
    using Xunit;

    public sealed class WhenIsEmptyIsCalled
    {
        [Fact]
        public void GivenAnEmptySourceThenAPositiveResponseIsReturned()
        {
            IEnumerable<int> source = new int[0];

            Assert.True(source.IsEmpty());
        }

        [Fact]
        public void GivenAnPopulatedSourceThenANegativeResponseIsReturned()
        {
            IEnumerable<int> source = new int[1];

            Assert.False(source.IsEmpty());
        }

        [Fact]
        public void GivenANullSourceThenAPositiveResponseIsReturned()
        {
            IEnumerable<int>? source = null;

            Assert.True(source.IsEmpty());
        }
    }
}