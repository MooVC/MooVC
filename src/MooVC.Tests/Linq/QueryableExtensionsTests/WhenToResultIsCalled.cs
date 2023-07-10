namespace MooVC.Linq.QueryableExtensionsTests;

using System.Linq;
using Xunit;

public sealed class WhenToResultIsCalled
{
    [Theory]
    [InlineData(new[] { 1, 2, 3 })]
    [InlineData(new int[0])]
    public void GivenNoPagingThenAnEmptyResultIsReturned(int[] expected)
    {
        IQueryable<int> query = expected.AsQueryable();
        PagedResult<int> result = query.ToResult(default);

        Assert.Equal(Paging.None, result.Request);
        Assert.Equal((ulong)expected.LongLength, result.Total);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, 1, 3, 6, new[] { 1, 2, 3, 4, 5, 6 })]
    [InlineData(new[] { 3, 4 }, 2, 2, 6, new[] { 1, 2, 3, 4, 5, 6 })]
    [InlineData(new int[0], 3, 2, 4, new[] { 1, 2, 3, 4 })]
    public void GivenPagingThenAnEmptyResultIsReturned(int[] expected, ushort page, ushort size, ulong total, int[] values)
    {
        var request = new Paging(page: page, size: size);
        IQueryable<int> query = values.AsQueryable();
        PagedResult<int> result = query.ToResult(request);

        Assert.Equal(request, result.Request);
        Assert.Equal(total, result.Total);
        Assert.Equal(expected, result);
    }
}