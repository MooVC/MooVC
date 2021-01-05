namespace MooVC.Persistence.AsyncMappedStoreTests
{
    using System;
    using MooVC.Persistence;
    using Moq;
    using Xunit;

    public sealed class WhenDeleteAsyncIsCalled
        : AsyncMappedStoreTests
    {
        [Fact]
        public async void GivenAKeyThenTheInnerMappingAndInnerStoreAreInvokedAsync()
        {
            bool wasInvoked = false;
            string? expectedInnerKey = default;

            string LocalInnerMapping(Guid key)
            {
                wasInvoked = true;

                expectedInnerKey = InnerMapping(key);

                return expectedInnerKey;
            }

            var key = Guid.NewGuid();

            var store = new AsyncMappedStore<object, Guid, string>(LocalInnerMapping, OutterMapping, Store.Object);

            await store.DeleteAsync(key);

            Assert.True(wasInvoked);

            Store.Verify(store => store.DeleteAsync(It.IsAny<string>()), times: Times.Once);
            Store.Verify(store => store.DeleteAsync(It.Is<string>(argument => argument == expectedInnerKey)), times: Times.Once);
        }

        [Fact]
        public async void GivenAnItemThenTheInnerStoreIsInvokedAsync()
        {
            object item = new object();

            var store = new AsyncMappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store.Object);

            await store.DeleteAsync(item);

            Store.Verify(store => store.DeleteAsync(It.IsAny<object>()), times: Times.Once);
        }
    }
}