namespace MooVC.Persistence.MappedStoreTests;

using System;
using System.Threading;
using FluentAssertions;
using NSubstitute;
using Xunit;

public sealed class WhenUpdateAsyncIsCalled
    : MappedStoreTests
{
    [Fact]
    public async void GivenAnItemThenTheInnerStoreIsInvokedAsync()
    {
        // Arrange
        object expectedItem = new();
        var store = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store);

        // Act
        Func<Task> act = async () => await store.UpdateAsync(expectedItem, CancellationToken.None);

        // Assert
        _ = await act.Should().NotThrowAsync();

        await Store.Received(1).UpdateAsync(Arg.Is<object>(parameter => parameter == expectedItem), Arg.Any<CancellationToken>());
    }
}