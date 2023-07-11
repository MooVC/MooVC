namespace MooVC.Persistence.MappedStoreTests;

using System;
using System.Threading;
using Moq;
using Xunit;

public sealed class WhenCreateAsyncIsCalled
    : MappedStoreTests
{
    [Fact]
    public async void GivenAnItemThenTheOutterMappingAndInnerStoreAreInvokedAndTheResultFromTheStoreIsReturnedAsync()
    {
        bool wasInvoked = false;

        Guid LocalOutterMapping(object item, string key)
        {
            wasInvoked = true;

            return OutterMapping(item, key);
        }

        var expectedOutterKey = Guid.NewGuid();
        string expectedInnerKey = expectedOutterKey.ToString();

        object item = new();

        _ = Store
            .Setup(store => store.CreateAsync(
                It.Is<object>(parameter => parameter == item),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedInnerKey);

        var store = new MappedStore<object, Guid, string>(InnerMapping, LocalOutterMapping, Store.Object);
        Guid actualOutterKey = await store.CreateAsync(item, CancellationToken.None);

        Assert.True(wasInvoked);
        Assert.Equal(expectedOutterKey, actualOutterKey);

        Store.Verify(store => store.CreateAsync(It.IsAny<object>(), It.IsAny<CancellationToken>()), times: Times.Once);
    }
}