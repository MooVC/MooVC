namespace MooVC.Persistence.MappedStoreTests;

public sealed class WhenUpdateAsyncIsCalled
    : MappedStoreTests
{
    [Fact]
    public async Task GivenAnItemThenTheInnerStoreIsInvoked()
    {
        // Arrange
        object expectedItem = new();
        var store = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store);

        // Act
        Func<Task> act = async () => await store.Update(expectedItem, CancellationToken.None);

        // Assert
        _ = await act.Should().NotThrowAsync();

        await Store.Received(1).Update(Arg.Is<object>(parameter => parameter == expectedItem), Arg.Any<CancellationToken>());
    }
}