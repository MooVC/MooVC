namespace MooVC.Linq.PagedResultTests;

using MooVC.Serialization;
using Xunit;

public sealed class WhenPagedResultIsSerialized
{
    [Theory]
    [InlineData(1, 10, 50, new[] { 1, 2, 3, 4 })]
    [InlineData(5, 0, 20, new int[0])]
    [InlineData(0, 100, 0, new[] { 1 })]
    public void GivenAnInstanceThenAllPropertiesAreSerialized(ushort page, ushort size, ulong total, int[] values)
    {
        var request = new Paging(page: page, size: size);
        var original = new PagedResult<int>(request, total, values);
        PagedResult<int> deserialized = original.Clone();

        Assert.Equal(original.Request.Page, deserialized.Request.Page);
        Assert.Equal(original.Request.Size, deserialized.Request.Size);
        Assert.Equal(original.Total, deserialized.Total);
        Assert.Equal(original.Values, deserialized.Values);
        Assert.NotSame(original, deserialized);
    }
}