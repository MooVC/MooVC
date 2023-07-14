namespace MooVC.Persistence.MappedStoreTests;

using System;
using System.Threading;
using FluentAssertions;
using Moq;
using Xunit;

public sealed class WhenDeleteAsyncIsCalled
    : MappedStoreTests
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

        // Arrange
        var key = Guid.NewGuid();

        var store = new MappedStore<object, Guid, string>(LocalInnerMapping, OutterMapping, Store.Object);

        // Act
        await store.DeleteAsync(key, CancellationToken.None);

        // Assert
        _ = wasInvoked.Should().BeTrue();

        Store.Verify(
            store => store.DeleteAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()),
            Times.Once);

        Store.Verify(
            store => store.DeleteAsync(
                It.Is<string>(argument => argument == expectedInnerKey),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async void GivenAnItemThenTheInnerStoreIsInvokedAsync()
    {
        // Arrange
        object item = new();

        var store = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store.Object);

        // Act
        await store.DeleteAsync(item, CancellationToken.None);

        // Assert
        Store.Verify(store => store.DeleteAsync(It.IsAny<object>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}