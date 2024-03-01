namespace MooVC.Persistence.MappedStoreTests;

public sealed class WhenUpdateAsyncIsCalled
    : MappedStoreTests
{
    [Fact]
    public async Task GivenAnItemThenTheInnerStoreIsInvokedAsync()
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