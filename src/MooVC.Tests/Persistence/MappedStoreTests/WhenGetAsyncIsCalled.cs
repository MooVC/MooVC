namespace MooVC.Persistence.MappedStoreTests;

using MooVC.Linq;

public sealed class WhenGetAsyncIsCalled
    : MappedStoreTests
{
    [Fact]
    public async Task GivenAKeyThenTheInnerMappingAndInnerStoreAreInvokedAsync()
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
    public async Task GivenPagingThenTheInnerStoreIsInvokedAsync()
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
    public async Task GivenANonExistingKeyThenNullShouldBeReturnedAsync()
    {
        // Arrange
        var outterKey = Guid.NewGuid();
        var store = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store);

        // Act
        object? actualItem = await store.GetAsync(outterKey, CancellationToken.None);

        // Assert
        _ = actualItem.Should().BeNull();
    }
}