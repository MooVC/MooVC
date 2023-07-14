namespace MooVC.Persistence.SynchronousStoreTests;

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

public sealed class WhenCreateAsyncIsCalled
{
    [Fact]
    public async Task GivenAnItemThenTheExpectedKeyIsReturnedAsync()
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
        int actualKey = await store.CreateAsync(ExpectedItem, CancellationToken.None);

        // Assert
        _ = actualKey.Should().Be(ExpectedKey);
    }

    [Fact]
    public async Task GivenAnExceptionThenTheExceptionIsThrownAsync()
    {
        // Arrange
        var store = new TestableSynchronousStore();

        // Act
        Func<Task> act = async () => await store.CreateAsync("Irrelevant Test Data", CancellationToken.None);

        // Assert
        _ = await act.Should().ThrowAsync<NotImplementedException>();
    }
}