namespace MooVC.Persistence.SynchronousStoreTests;

using System;
using System.Threading.Tasks;
using Xunit;

public sealed class WhenCreateAsyncIsCalled
{
    [Fact]
    public async Task GivenAnItemThenTheExpectedKeyIsReturnedAsync()
    {
        const string ExpectedItem = "Something something dark side...";
        const int ExpectedKey = 1;

        var store = new TestableSynchronousStore(create: item =>
        {
            Assert.Equal(ExpectedItem, item);

            return ExpectedKey;
        });
        int actualKey = await store.CreateAsync(ExpectedItem);

        Assert.Equal(ExpectedKey, actualKey);
    }

    [Fact]
    public async Task GivenAnExceptionThenTheExceptionIsThrownAsync()
    {
        var store = new TestableSynchronousStore();

        _ = await Assert.ThrowsAsync<NotImplementedException>(
            () => store.CreateAsync("Irrelevant Test Data"));
    }
}