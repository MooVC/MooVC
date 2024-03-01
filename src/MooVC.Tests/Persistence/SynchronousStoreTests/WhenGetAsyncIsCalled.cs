namespace MooVC.Persistence.SynchronousStoreTests;

using MooVC.Linq;

public sealed class WhenGetAsyncIsCalled
{
    [Fact]
    public async Task GivenAKeyThenTheExpectedItemIsReturnedAsync()
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
        string? actualItem = await store.GetAsync(ExpectedKey, CancellationToken.None);

        // Assert
        _ = actualItem.Should().Be(ExpectedItem);
    }

    [Fact]
    public async Task GivenPagingThenTheExpectedItemsAreReturnedAsync()
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
        PagedResult<string> actual = await store.GetAsync(paging: expectedPaging);

        // Assert
        _ = actual.Should().BeEquivalentTo(expectedResults);
    }

    [Fact]
    public async Task GivenAKeyWhenAnExceptionOccursThenTheExceptionIsThrownAsync()
    {
        // Arrange
        var store = new TestableSynchronousStore();

        // Act
        Func<Task> act = async () => await store.GetAsync(3);

        // Assert
        _ = await act.Should().ThrowAsync<NotImplementedException>();
    }

    [Fact]
    public async Task GivenPagingWhenAnExceptionOccursThenTheExceptionIsThrownAsync()
    {
        // Arrange
        var store = new TestableSynchronousStore();

        // Act
        Func<Task> act = async () => await store.GetAsync(paging: Paging.Default);

        // Assert
        _ = await act.Should().ThrowAsync<NotImplementedException>();
    }
}