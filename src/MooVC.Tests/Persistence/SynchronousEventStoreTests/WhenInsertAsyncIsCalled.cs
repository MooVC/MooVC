namespace MooVC.Persistence.SynchronousEventStoreTests
{
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenInsertAsyncIsCalled
    {
        [Fact]
        public async Task GivenAnItemThenTheExpectedIndexIsReturnedAsync()
        {
            const int ExpectedIndex = 1;
            object expectedItem = new object();

            var store = new TestableSynchronousEventStore(insert: item =>
            {
                Assert.Equal(expectedItem, item);

                return ExpectedIndex;
            });

            int actualIndex = await store.InsertAsync(expectedItem);

            Assert.Equal(ExpectedIndex, actualIndex);
        }

        [Fact]
        public async Task GivenAnExceptionThenTheExceptionIsThrownAsync()
        {
            var store = new TestableSynchronousEventStore();

            _ = await Assert.ThrowsAsync<NotImplementedException>(
                () => store.InsertAsync(default!));
        }
    }
}