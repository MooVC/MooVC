namespace MooVC.Persistence.MappedStoreTests;

using System;
using System.Threading;
using FluentAssertions;
using Moq;
using Xunit;

public sealed class WhenUpdateAsyncIsCalled
    : MappedStoreTests
{
    [Fact]
    public async void GivenAnItemThenTheInnerStoreIsInvokedAsync()
    {
        // Arrange
        object expectedItem = new();
        var store = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store.Object);

        // Act
        Func<Task> act = async () => await store.UpdateAsync(expectedItem, CancellationToken.None);

        // Assert
        _ = await act.Should().NotThrowAsync();

        Store.Verify(
            store => store.UpdateAsync(It.Is<object>(parameter => parameter == expectedItem), It.IsAny<CancellationToken>()),
            Times.Once);
    }
}