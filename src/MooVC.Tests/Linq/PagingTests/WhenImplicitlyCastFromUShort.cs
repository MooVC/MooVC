namespace MooVC.Linq.PagingTests;

using Xunit;

public sealed class WhenImplicitlyCastFromUShort
{
    [Theory]
    [InlineData(Paging.MinimumSize, ushort.MinValue)]
    [InlineData(5, 5)]
    [InlineData(ushort.MaxValue, ushort.MaxValue)]
    public void GivenAValueThenAnInstanceIsReturnedWithTheExpectedSize(ushort expected, ushort size)
    {
        Paging paging = size;

        Assert.Equal(Paging.FirstPage, paging.Page);
        Assert.Equal(expected, paging.Size);
    }

    [Fact]
    public void GivenASizeOfDefaultThenDefaultIsReturned()
    {
        Paging paging = Paging.DefaultSize;

        Assert.Same(Paging.Default, paging);
    }

    [Fact]
    public void GivenASizeOfOneThenOneIsReturned()
    {
        Paging paging = 1;

        Assert.Same(Paging.One, paging);
    }

    [Fact]
    public void GivenSizeOfMaxThenNoneIsReturned()
    {
        Paging paging = ushort.MaxValue;

        Assert.Same(Paging.None, paging);
    }
}