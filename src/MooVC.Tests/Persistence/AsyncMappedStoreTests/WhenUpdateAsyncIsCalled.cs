namespace MooVC.Persistence.AsyncMappedStoreTests
{
    using System;
    using MooVC.Persistence;
    using Moq;
    using Xunit;

    public sealed class WhenUpdateAsyncIsCalled
        : AsyncMappedStoreTests
    {
        [Fact]
        public async void GivenAnItemThenTheInnerStoreIsInvokedAsync()
        {
            var store = new AsyncMappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store.Object);

            await store.UpdateAsync(new object());

            Store.Verify(store => store.UpdateAsync(It.IsAny<object>()), times: Times.Once);
        }
    }
}