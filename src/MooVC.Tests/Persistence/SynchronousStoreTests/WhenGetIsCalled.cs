namespace MooVC.Persistence.SynchronousStoreTests;

using MooVC.Linq;

public sealed class WhenGetIsCalled
{
    [Fact]
    public async Task GivenAKeyThenTheExpectedItemIsReturned()
    {
        // Arrange
        const string ExpectedItem = "Something something dark side...";
        const int ExpectedKey = 1;

        var store = new TestableSynchronousStore(getByKey: key =>
        {
            _ = key.Should().Be(ExpectedKey);

            return ExpectedItem;
        });

        // Act
        string? actualItem = await store.Get(ExpectedKey, CancellationToken.None);

        // Assert
        _ = actualItem.Should().Be(ExpectedItem);
    }

    [Fact]
    public async Task GivenPagingThenTheExpectedItemsAreReturned()
    {
        // Arrange
        var expectedPaging = new Paging();
        string[] expectedResults = ["Something", "Dark", "Side"];

        var store = new TestableSynchronousStore(getAll: actualPaging =>
        {
            _ = actualPaging.Should().Be(expectedPaging);

            return new PagedResult<string>(expectedPaging, expectedResults);
        });

        // Act
        PagedResult<string> actual = await store.Get(paging: expectedPaging);

        // Assert
        _ = actual.Should().BeEquivalentTo(expectedResults);
    }

    [Fact]
    public async Task GivenAKeyWhenAnExceptionOccursThenTheExceptionIsThrown()
    {
        // Arrange
        var store = new TestableSynchronousStore();

        // Act
        Func<Task> act = async () => await store.Get(3);

        // Assert
        _ = await act.Should().ThrowAsync<NotImplementedException>();
    }

    [Fact]
    public async Task GivenPagingWhenAnExceptionOccursThenTheExceptionIsThrown()
    {
        // Arrange
        var store = new TestableSynchronousStore();

        // Act
        Func<Task> act = async () => await store.Get(paging: Paging.Default);

        // Assert
        _ = await act.Should().ThrowAsync<NotImplementedException>();
    }
}