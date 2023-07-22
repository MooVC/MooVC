namespace MooVC.Persistence.MappedStoreTests;

using System;
using System.Threading;
using FluentAssertions;
using MooVC.Linq;
using Moq;
using Xunit;

public sealed class WhenGetAsyncIsCalled
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
        var outterKey = Guid.NewGuid();
        object expectedItem = new();

        _ = Store
            .Setup(store => store.GetAsync(
                It.Is<string>(parameter => parameter == expectedInnerKey),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedItem);

        var store = new MappedStore<object, Guid, string>(LocalInnerMapping, OutterMapping, Store.Object);

        // Act
        object? actualItem = await store.GetAsync(outterKey, CancellationToken.None);

        // Assert
        _ = wasInvoked.Should().BeTrue();
        _ = actualItem.Should().Be(expectedItem);

        Store.Verify(
            store => store.GetAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async void GivenPagingThenTheInnerStoreIsInvokedAsync()
    {
        // Arrange
        var paging = new Paging();

        var store = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store.Object);

        // Act
        _ = await store.GetAsync(paging: paging);

        // Assert
        Store.Verify(
            store => store.GetAsync(It.IsAny<Paging>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async void GivenANonExistingKeyThenNullShouldBeReturnedAsync()
    {
        // Arrange
        var outterKey = Guid.NewGuid();
        object expectedItem = new();

        var store = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store.Object);

        // Act
        object? actualItem = await store.GetAsync(outterKey, CancellationToken.None);

        // Assert
        _ = actualItem.Should().BeNull();
    }
}