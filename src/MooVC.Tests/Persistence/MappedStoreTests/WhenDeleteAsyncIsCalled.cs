namespace MooVC.Persistence.MappedStoreTests;

public sealed class WhenDeleteAsyncIsCalled
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
        var key = Guid.NewGuid();

        var store = new MappedStore<object, Guid, string>(LocalInnerMapping, OutterMapping, Store);

        // Act
        await store.DeleteAsync(key, CancellationToken.None);

        // Assert
        _ = wasInvoked.Should().BeTrue();

        await Store.Received(1).DeleteAsync(Arg.Is<string>(key => key == expectedInnerKey), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task GivenAnItemThenTheInnerStoreIsInvokedAsync()
    {
        // Arrange
        object item = new();

        var store = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store);

        // Act
        await store.DeleteAsync(item, CancellationToken.None);

        // Assert
        await Store.Received(1).DeleteAsync(item, Arg.Any<CancellationToken>());
    }
}