namespace MooVC.Persistence.MappedStoreTests;

using System;
using System.Threading;
using FluentAssertions;
using MooVC.Linq;
using NSubstitute;
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
            .GetAsync(Arg.Is<string>(parameter => parameter == expectedInnerKey), Arg.Any<CancellationToken>())
            .Returns(expectedItem);

        var store = new MappedStore<object, Guid, string>(LocalInnerMapping, OutterMapping, Store);

        // Act
        object? actualItem = await store.GetAsync(outterKey, CancellationToken.None);

        // Assert
        _ = wasInvoked.Should().BeTrue();
        _ = actualItem.Should().Be(expectedItem);

        _ = await Store.Received(1).GetAsync(Arg.Any<string>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async void GivenPagingThenTheInnerStoreIsInvokedAsync()
    {
        // Arrange
        var paging = new Paging();

        var store = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store);

        // Act
        _ = await store.GetAsync(paging: paging);

        // Assert
        _ = await Store.Received(1).GetAsync(paging, Arg.Any<CancellationToken>());
    }

    [Fact]
    public async void GivenANonExistingKeyThenNullShouldBeReturnedAsync()
    {
        // Arrange
        var outterKey = Guid.NewGuid();
        object expectedItem = new();

        var store = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store);

        // Act
        object? actualItem = await store.GetAsync(outterKey, CancellationToken.None);

        // Assert
        _ = actualItem.Should().BeNull();
    }
}