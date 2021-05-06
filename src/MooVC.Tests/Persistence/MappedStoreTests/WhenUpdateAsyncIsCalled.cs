namespace MooVC.Persistence.MappedStoreTests
{
    using System;
    using Moq;
    using Xunit;

    public sealed class WhenUpdateAsyncIsCalled
        : MappedStoreTests
    {
        [Fact]
        public async void GivenAnItemThenTheInnerStoreIsInvokedAsync()
        {
            var store = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store.Object);

            await store.UpdateAsync(new object());

            Store.Verify(store => store.UpdateAsync(It.IsAny<object>()), times: Times.Once);
        }
    }
}