namespace MooVC.Persistence.SynchronousStoreTests;

public sealed class WhenDeleteAsyncIsCalled
{
    [Fact]
    public async Task GivenAKeyThenTheDeleteIsInvokedWithTheKey()
    {
        // Arrange
        const int ExpectedKey = 1;
        bool wasInvoked = false;

        var store = new TestableSynchronousStore(deleteByKey: key =>
        {
            wasInvoked = true;
            _ = key.Should().Be(ExpectedKey);
        });

        // Act
        await store.Delete(ExpectedKey, CancellationToken.None);

        // Assert
        _ = wasInvoked.Should().BeTrue();
    }

    [Fact]
    public async Task GivenAnItemThenTheDeleteIsInvokedWithTheKey()
    {
        // Arrange
        const string ExpectedItem = "Something something dark side...";
        bool wasInvoked = false;

        var store = new TestableSynchronousStore(deleteByItem: item =>
        {
            wasInvoked = true;
            _ = item.Should().Be(ExpectedItem);
        });

        // Act
        await store.Delete(ExpectedItem, CancellationToken.None);

        // Assert
        _ = wasInvoked.Should().BeTrue();
    }

    [Fact]
    public async Task GivenAKeyWhenAnExceptionOccursThenTheExceptionIsThrown()
    {
        // Arrange
        var store = new TestableSynchronousStore();

        // Act
        Func<Task> act = async () => await store.Delete(2, CancellationToken.None);

        // Assert
        _ = await act.Should().ThrowAsync<NotImplementedException>();
    }

    [Fact]
    public async Task GivenAnItemWhenAnExceptionOccursThenTheExceptionIsThrown()
    {
        // Arrange
        var store = new TestableSynchronousStore();

        // Act
        Func<Task> act = async () => await store.Delete("Something Irrelevant", CancellationToken.None);

        // Assert
        _ = await act.Should().ThrowAsync<NotImplementedException>();
    }
}