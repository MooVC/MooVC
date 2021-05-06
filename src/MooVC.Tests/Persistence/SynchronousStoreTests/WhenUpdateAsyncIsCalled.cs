namespace MooVC.Persistence.SynchronousStoreTests
{
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenUpdateAsyncIsCalled
    {
        [Fact]
        public async Task GivenAnItemThenTheUpdateIsInvokedWithTheKeyAsync()
        {
            const string ExpectedItem = "Something something dark side...";
            bool wasInvoked = false;

            var store = new TestableSynchronousStore(update: item =>
            {
                wasInvoked = true;

                Assert.Equal(ExpectedItem, item);
            });

            await store.UpdateAsync(ExpectedItem);

            Assert.True(wasInvoked);
        }

        [Fact]
        public async Task GivenAnItemWhenAnExceptionOccursThenTheExceptionIsThrownAsync()
        {
            var store = new TestableSynchronousStore();

            _ = await Assert.ThrowsAsync<NotImplementedException>(
                () => store.UpdateAsync("Something Irrelevant"));
        }
    }
}