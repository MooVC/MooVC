namespace MooVC.Persistence.SynchronousStoreTests;

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

public sealed class WhenUpdateIsCalled
{
    [Fact]
    public async Task GivenAnItemThenTheUpdateIsInvokedWithTheKey()
    {
        // Arrange
        const string ExpectedItem = "Something something dark side...";
        bool wasInvoked = false;

        var store = new TestableSynchronousStore(update: item =>
        {
            wasInvoked = true;
            _ = item.Should().Be(ExpectedItem);
        });

        // Act
        await store.Update(ExpectedItem, CancellationToken.None);

        // Assert
        _ = wasInvoked.Should().BeTrue();
    }

    [Fact]
    public async Task GivenAnItemWhenAnExceptionOccursThenTheExceptionIsThrown()
    {
        // Arrange
        var store = new TestableSynchronousStore();

        // Act
        Func<Task> act = async () => await store.Update("Something Irrelevant", CancellationToken.None);

        // Assert
        _ = await act.Should().ThrowAsync<NotImplementedException>();
    }
}