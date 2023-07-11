namespace MooVC.Persistence.MappedStoreTests;

using System;
using System.Threading;
using Moq;
using Xunit;

public sealed class WhenUpdateAsyncIsCalled
    : MappedStoreTests
{
    [Fact]
    public async void GivenAnItemThenTheInnerStoreIsInvokedAsync()
    {
        var store = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store.Object);

        await store.UpdateAsync(new object(), CancellationToken.None);

        Store.Verify(store => store.UpdateAsync(It.IsAny<object>(), It.IsAny<CancellationToken>()), times: Times.Once);
    }
}