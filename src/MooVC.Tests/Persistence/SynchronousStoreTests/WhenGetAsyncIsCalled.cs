namespace MooVC.Persistence.SynchronousStoreTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MooVC.Linq;
using Xunit;

public sealed class WhenGetAsyncIsCalled
{
    [Fact]
    public async Task GivenAnKeyThenTheExpectedItemIsReturnedAsync()
    {
        const string ExpectedItem = "Something something dark side...";
        const int ExpectedKey = 1;

        var store = new TestableSynchronousStore(getByKey: key =>
        {
            Assert.Equal(ExpectedKey, key);

            return ExpectedItem;
        });

        string? actualItem = await store.GetAsync(ExpectedKey);

        Assert.Equal(ExpectedItem, actualItem);
    }

    [Fact]
    public async Task GivenPagingThenTheExpectedItemsAreReturnedAsync()
    {
        var expected = new Paging();
        string[] results = new[] { "Something", "Dark", "Side" };

        var store = new TestableSynchronousStore(getAll: actual =>
        {
            Assert.Equal(expected, actual);

            return new PagedResult<string>(expected, results);
        });

        PagedResult<string> actual = await store.GetAsync(paging: expected);

        Assert.Equal(results, actual);
    }

    [Fact]
    public async Task GiveAKeyWhennAnExceptionOccursThenTheExceptionIsThrownAsync()
    {
        var store = new TestableSynchronousStore();

        _ = await Assert.ThrowsAsync<NotImplementedException>(
            () => store.GetAsync(3));
    }

    [Fact]
    public async Task GivenPagingWhenAnExceptionOccursThenTheExceptionIsThrownAsync()
    {
        var store = new TestableSynchronousStore();

        _ = await Assert.ThrowsAsync<NotImplementedException>(
            () => store.GetAsync(paging: Paging.Default));
    }
}