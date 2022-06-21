namespace MooVC.Linq.PagingTests;

using Xunit;

public sealed class WhenNextIsCalled
{
    [Theory]
    [InlineData(0, 2, 25)]
    [InlineData(1, 2, 1)]
    [InlineData(4, 5, 10)]
    [InlineData(ushort.MaxValue, ushort.MaxValue, 5)]
    public void GivenAPageThenPagingForTheNextIncrementIsReturned(
        ushort current,
        ushort expected,
        ushort size)
    {
        var page = new Paging(page: current, size: size);
        Paging next = page.Next();

        Assert.Equal(expected, next.Page);
        Assert.Equal(size, next.Size);
    }
}