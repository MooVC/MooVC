namespace MooVC.Linq.PagingTests
{
    using Xunit;

    public sealed class WhenIsDefaultIsCalled
    {
        [Fact]
        public void GivenThePagingDefaultThenAPositiveResponseIsReturned()
        {
            Assert.True(Paging.Default.IsDefault);
        }

        [Fact]
        public void GivenAPagingInstanceThenANegativeResponseIsReturned()
        {
            var paging = new Paging();

            Assert.False(paging.IsDefault);
        }
    }
}