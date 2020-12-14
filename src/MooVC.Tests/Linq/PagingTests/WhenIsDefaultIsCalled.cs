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
        public void GivenAPagingInstanceThatUsesDefaultSettingsThenAPositiveResponseIsReturned()
        {
            var paging = new Paging();

            Assert.True(paging.IsDefault);
        }

        [Fact]
        public void GivenAPagingInstanceThatDoesNotUseDefaultSettingsThenANegativeResponseIsReturned()
        {
            var paging = new Paging
            {
                Page = 2,
                Size = 5,
            };

            Assert.False(paging.IsDefault);
        }
    }
}