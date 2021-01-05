﻿namespace MooVC.Persistence.AsyncMappedStoreTests
{
    using System;
    using MooVC.Persistence;
    using Moq;
    using Xunit;

    public sealed class WhenCreateAsyncIsCalled
        : AsyncMappedStoreTests
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

            object item = new object();

            _ = Store
                .Setup(store => store.CreateAsync(It.Is<object>(parameter => parameter == item)))
                .ReturnsAsync(expectedInnerKey);

            var store = new AsyncMappedStore<object, Guid, string>(InnerMapping, LocalOutterMapping, Store.Object);
            Guid actualOutterKey = await store.CreateAsync(item);

            Assert.True(wasInvoked);
            Assert.Equal(expectedOutterKey, actualOutterKey);

            Store.Verify(store => store.CreateAsync(It.IsAny<object>()), times: Times.Once);
        }
    }
}