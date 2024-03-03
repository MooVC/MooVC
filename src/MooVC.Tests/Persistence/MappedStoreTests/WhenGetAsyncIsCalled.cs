namespace MooVC.Persistence.MappedStoreTests;

using MooVC.Linq;

public sealed class WhenGetAsyncIsCalled
    : MappedStoreTests
{
    [Fact]
    public async Task GivenAKeyThenTheInnerMappingAndInnerStoreAreInvoked()
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
            .Get(Arg.Is<string>(parameter => parameter == expectedInnerKey), Arg.Any<CancellationToken>())
            .Returns(expectedItem);

        var store = new MappedStore<object, Guid, string>(LocalInnerMapping, OutterMapping, Store);

        // Act
        object? actualItem = await store.Get(outterKey, CancellationToken.None);

        // Assert
        _ = wasInvoked.Should().BeTrue();
        _ = actualItem.Should().Be(expectedItem);

        _ = await Store.Received(1).Get(Arg.Any<string>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task GivenPagingThenTheInnerStoreIsInvoked()
    {
        // Arrange
        var paging = new Paging();

        var store = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store);

        // Act
        _ = await store.Get(paging: paging);

        // Assert
        _ = await Store.Received(1).Get(paging, Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task GivenANonExistingKeyThenNullShouldBeReturned()
    {
        // Arrange
        var outterKey = Guid.NewGuid();
        var store = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store);

        // Act
        object? actualItem = await store.Get(outterKey, CancellationToken.None);

        // Assert
        _ = actualItem.Should().BeNull();
    }
}