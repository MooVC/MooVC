namespace MooVC.Persistence.SynchronousEventStoreTests
{
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenGetAsyncIsCalled
    {
        [Fact]
        public async Task GivenAnIndexThenTheExpectedItemIsReturnedAsync()
        {
            const int ExpectedIndex = 1;
            object expectedItem = new object();

            var store = new TestableSynchronousEventStore(getByIndex: index =>
            {
                Assert.Equal(ExpectedIndex, index);

                return expectedItem;
            });

            object? actualItem = await store.GetAsync(ExpectedIndex);

            Assert.Equal(expectedItem, actualItem);
        }

        [Fact]
        public async Task GivenAnIndexWhenAnExceptionOccursThenTheExceptionIsThrownAsync()
        {
            var store = new TestableSynchronousEventStore();

            _ = await Assert.ThrowsAsync<NotImplementedException>(
                () => store.GetAsync(3));
        }
    }
}