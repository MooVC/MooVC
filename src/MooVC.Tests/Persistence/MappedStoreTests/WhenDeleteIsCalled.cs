namespace MooVC.Persistence.MappedStoreTests;

public sealed class WhenDeleteIsCalled
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
        var key = Guid.NewGuid();

        var store = new MappedStore<object, Guid, string>(LocalInnerMapping, OutterMapping, Store);

        // Act
        await store.Delete(key, CancellationToken.None);

        // Assert
        _ = wasInvoked.Should().BeTrue();

        await Store.Received(1).Delete(Arg.Is<string>(key => key == expectedInnerKey), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task GivenAnItemThenTheInnerStoreIsInvoked()
    {
        // Arrange
        object item = new();

        var store = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store);

        // Act
        await store.Delete(item, CancellationToken.None);

        // Assert
        await Store.Received(1).Delete(item, Arg.Any<CancellationToken>());
    }
}