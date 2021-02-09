namespace MooVC.Persistence.StoreTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MooVC.Linq;
    using Xunit;

    public sealed class WhenGetAsyncIsCalled
    {
        [Fact]
        public async Task GivenAnKeyThenTheExpectedItemIsReturnedAsync()
        {
            const string ExpectedItem = "Something something dark side...";
            const int ExpectedKey = 1;

            var store = new TestableStore(getByKey: key =>
            {
                Assert.Equal(ExpectedKey, key);

                return ExpectedItem;
            });

            string? actualItem = await store.GetAsync(ExpectedKey);

            Assert.Equal(ExpectedItem, actualItem);
        }

        [Fact]
        public async Task GivenPagingThenTheExpectedItemsAreReturnedAsync()
        {
            var expected = new Paging();
            string[] results = new[] { "Something", "Dark", "Side" };

            var store = new TestableStore(getAll: actual =>
            {
                Assert.Equal(expected, actual);

                return results;
            });

            IEnumerable<string> actual = await store.GetAsync(paging: expected);

            Assert.Equal(results, actual);
        }

        [Fact]
        public async Task GiveAKeyWhennAnExceptionOccursThenTheExceptionIsThrownAsync()
        {
            var store = new TestableStore();

            _ = await Assert.ThrowsAsync<NotImplementedException>(
                () => store.GetAsync(3));
        }

        [Fact]
        public async Task GivenPagingWhenAnExceptionOccursThenTheExceptionIsThrownAsync()
        {
            var store = new TestableStore();

            _ = await Assert.ThrowsAsync<NotImplementedException>(
                () => store.GetAsync(paging: Paging.Default));
        }
    }
}