namespace MooVC.Persistence.SynchronousStoreTests;

using System;
using System.Threading.Tasks;
using Xunit;

public sealed class WhenDeleteAsyncIsCalled
{
    [Fact]
    public async Task GivenAnKeyThenTheDeleteIsInvokedWithTheKeyAsync()
    {
        const int ExpectedKey = 1;
        bool wasInvoked = false;

        var store = new TestableSynchronousStore(deleteByKey: key =>
        {
            wasInvoked = true;

            Assert.Equal(ExpectedKey, key);
        });

        await store.DeleteAsync(ExpectedKey);

        Assert.True(wasInvoked);
    }

    [Fact]
    public async Task GivenAnItemThenTheDeleteIsInvokedWithTheKeyAsync()
    {
        const string ExpectedItem = "Something something dark side...";
        bool wasInvoked = false;

        var store = new TestableSynchronousStore(deleteByItem: item =>
        {
            wasInvoked = true;

            Assert.Equal(ExpectedItem, item);
        });

        await store.DeleteAsync(ExpectedItem);

        Assert.True(wasInvoked);
    }

    [Fact]
    public async Task GivenAKeyWhenAnExceptionOccursThenTheExceptionIsThrownAsync()
    {
        var store = new TestableSynchronousStore();

        _ = await Assert.ThrowsAsync<NotImplementedException>(
            () => store.DeleteAsync(2));
    }

    [Fact]
    public async Task GivenAnItemWhenAnExceptionOccursThenTheExceptionIsThrownAsync()
    {
        var store = new TestableSynchronousStore();

        _ = await Assert.ThrowsAsync<NotImplementedException>(
            () => store.DeleteAsync("Something Irrelevant"));
    }
}