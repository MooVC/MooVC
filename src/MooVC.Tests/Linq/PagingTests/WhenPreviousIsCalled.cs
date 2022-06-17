namespace MooVC.Linq.PagingTests;

using Xunit;

public sealed class WhenPreviousIsCalled
{
    [Theory]
    [InlineData(ushort.MinValue, 1, 9)]
    [InlineData(1, 1, 25)]
    [InlineData(2, 1, 1)]
    [InlineData(5, 4, 10)]
    [InlineData(ushort.MaxValue, 65534, 5)]
    public void GivenAPageThenPagingForThePreviousDecrementIsReturned(
        ushort current,
        ushort expected,
        ushort size)
    {
        var page = new Paging(page: current, size: size);
        Paging previous = page.Previous();

        Assert.Equal(expected, previous.Page);
        Assert.Equal(size, previous.Size);
    }
}