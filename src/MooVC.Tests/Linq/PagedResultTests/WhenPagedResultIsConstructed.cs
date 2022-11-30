namespace MooVC.Linq.PagedResultTests;

using System;
using Xunit;

public sealed class WhenPagedResultIsConstructed
{
    [Theory]
    [InlineData(1, 10)]
    [InlineData(5, 0)]
    [InlineData(0, 100)]
    public void GivenNoValuesThenAllPropertiesAreSetToDefaults(ushort page, ushort size)
    {
        var request = new Paging(page: page, size: size);

        var result = new PagedResult<int>(request);

        Assert.False(result.HasResults);
        Assert.True(result.IsEmpty);
        Assert.Equal(request, result.Request);
    }

    [Theory]
    [InlineData(1, 10, new[] { 1, 2, 3, 4 })]
    [InlineData(5, 0, new int[0])]
    [InlineData(0, 100, new[] { 1 })]
    public void GivenValuesAndNoTotalThenAllPropertiesAreSet(ushort page, ushort size, int[] values)
    {
        var request = new Paging(page: page, size: size);

        var result = new PagedResult<int>(request, values);

        Assert.Equal(request, result.Request);
        Assert.Equal((ulong)values.LongLength, result.Total);
        Assert.Equal(values, result.Values);
    }

    [Theory]
    [InlineData(1, 10, 50, new[] { 1, 2, 3, 4 })]
    [InlineData(5, 0, 20, new int[0])]
    [InlineData(0, 100, 0, new[] { 1 })]
    public void GivenValuesAndAnIntTotalThenAllPropertiesAreSet(ushort page, ushort size, int total, int[] values)
    {
        var request = new Paging(page: page, size: size);

        var result = new PagedResult<int>(request, total, values);

        Assert.Equal(request, result.Request);
        Assert.Equal((ulong)total, result.Total);
        Assert.Equal(values, result.Values);
    }

    [Theory]
    [InlineData(1, 10, 50, new[] { 1, 2, 3, 4 })]
    [InlineData(5, 0, 20, new int[0])]
    [InlineData(0, 100, 0, new[] { 1 })]
    public void GivenValuesAndALongTotalThenAllPropertiesAreSet(ushort page, ushort size, long total, int[] values)
    {
        var request = new Paging(page: page, size: size);

        var result = new PagedResult<int>(request, total, values);

        Assert.Equal(request, result.Request);
        Assert.Equal((ulong)total, result.Total);
        Assert.Equal(values, result.Values);
    }

    [Theory]
    [InlineData(1, 10, 50, new[] { 1, 2, 3, 4 })]
    [InlineData(5, 0, 20, new int[0])]
    [InlineData(0, 100, 0, new[] { 1 })]
    public void GivenValuesAndAUlongTotalThenAllPropertiesAreSet(ushort page, ushort size, ulong total, int[] values)
    {
        var request = new Paging(page: page, size: size);

        var result = new PagedResult<int>(request, total, values);

        Assert.Equal(request, result.Request);
        Assert.Equal(total, result.Total);
        Assert.Equal(values, result.Values);
    }

    [Theory]
    [InlineData(new int[0])]
    [InlineData(default(int[]))]
    public void GivenEmptyValuesThenEmptyValuesAreSet(int[] values)
    {
        var request = new Paging(page: 1, size: 120);

        var result = new PagedResult<int>(request, 5, values);

        Assert.False(result.HasResults);
        Assert.True(result.IsEmpty);
        Assert.NotNull(result.Values);
        Assert.Empty(result.Values);
    }

    [Fact]
    public void GivenANullRequestThenAnArgumentNullExceptionIsThrown()
    {
        Paging? request = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => new PagedResult<int>(request!, 5, new[] { 1 }));

        Assert.Equal(nameof(request), exception.ParamName);
    }
}