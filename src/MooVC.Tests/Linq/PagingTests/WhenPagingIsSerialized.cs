namespace MooVC.Linq.PagingTests;

using MooVC.Serialization;
using Xunit;

public sealed class WhenPagingIsSerialized
{
    [Theory]
    [InlineData(Paging.FirstPage, Paging.MinimumSize)]
    [InlineData(Paging.FirstPage + 5, Paging.MinimumSize + 10)]
    [InlineData(Paging.FirstPage, ushort.MaxValue)]
    [InlineData(ushort.MaxValue, Paging.MinimumSize)]
    public void GivenAnInstanceThenAllPropertiesAreSerialized(ushort page, ushort size)
    {
        var paging = new Paging(page: page, size: size);
        Paging deserialized = paging.Clone();

        Assert.Equal(paging.Page, deserialized.Page);
        Assert.Equal(paging.Size, deserialized.Size);
        Assert.NotSame(paging, deserialized);
    }
}