namespace MooVC.Linq.PagingTests;

using Xunit;

public sealed class WhenImplicitlyCastFromTuple
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(5, 4)]
    [InlineData(ushort.MaxValue, Paging.MinimumSize)]
    [InlineData(Paging.FirstPage, ushort.MaxValue)]
    [InlineData(ushort.MaxValue, ushort.MaxValue)]
    public void GivenAValueThenAnInstanceIsReturnedWithTheExpectedSize(ushort page, ushort size)
    {
        Paging paging = (page, size);

        Assert.Equal(page, paging.Page);
        Assert.Equal(size, paging.Size);
    }

    [Fact]
    public void GivenAPageOfOneAndASizeOfDefaultThenDefaultIsReturned()
    {
        Paging paging = (1, Paging.DefaultSize);

        Assert.Same(Paging.Default, paging);
    }

    [Fact]
    public void GivenAPageOfOneAndASizeOfOneThenOneIsReturned()
    {
        Paging paging = (1, 1);

        Assert.Same(Paging.One, paging);
    }

    [Fact]
    public void GivenAPageOfOneAndASizeOfMaxThenNoneIsReturned()
    {
        Paging paging = (1, ushort.MaxValue);

        Assert.Same(Paging.None, paging);
    }
}