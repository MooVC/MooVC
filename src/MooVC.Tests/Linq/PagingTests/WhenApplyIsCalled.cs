namespace MooVC.Linq.PagingTests;

using System.Linq;
using Xunit;

public sealed class WhenApplyIsCalled
{
    [Theory]
    [InlineData(1, 5, new int[] { 0, 1, 2, 3, 4 })]
    [InlineData(2, 1, new int[] { 1 })]
    [InlineData(10, 2, new int[] { 18, 19 })]
    public void GivenAQueryableThenTheResultsArePagedAsConfigured(ushort page, ushort size, int[] expected)
    {
        var paging = new Paging(page: page, size: size);
        IQueryable<int> queryable = Enumerable.Range(0, 20).AsQueryable();
        IQueryable<int> result = paging.Apply(queryable);

        Assert.NotSame(queryable, result);

        int[] actual = result.ToArray();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenAQueryableWhenNoneIsProvidedThenTheQueryableIsReturnedUnchanged()
    {
        Paging paging = Paging.None;
        IQueryable<int> expected = Enumerable.Range(0, 20).AsQueryable();
        IQueryable<int> actual = paging.Apply(expected);

        Assert.Same(expected, actual);
    }
}