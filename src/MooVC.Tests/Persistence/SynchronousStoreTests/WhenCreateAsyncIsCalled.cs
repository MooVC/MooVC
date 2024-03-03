namespace MooVC.Persistence.SynchronousStoreTests;

public sealed class WhenCreateAsyncIsCalled
{
    [Fact]
    public async Task GivenAnItemThenTheExpectedKeyIsReturned()
    {
        // Arrange
        const string ExpectedItem = "Something something dark side...";
        const int ExpectedKey = 1;

        var store = new TestableSynchronousStore(create: item =>
        {
            _ = item.Should().Be(ExpectedItem);

            return ExpectedKey;
        });

        // Act
        int actualKey = await store.Create(ExpectedItem, CancellationToken.None);

        // Assert
        _ = actualKey.Should().Be(ExpectedKey);
    }

    [Fact]
    public async Task GivenAnExceptionThenTheExceptionIsThrown()
    {
        // Arrange
        var store = new TestableSynchronousStore();

        // Act
        Func<Task> act = async () => await store.Create("Irrelevant Test Data", CancellationToken.None);

        // Assert
        _ = await act.Should().ThrowAsync<NotImplementedException>();
    }
}