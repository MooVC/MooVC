namespace MooVC.Linq.PagedResultTests;

using Xunit;

public sealed class WhenImplicitlyCastToArray
{
    [Theory]
    [InlineData(new[] { 1, 2, 3 })]
    [InlineData(new[] { 1 })]
    [InlineData(new int[0])]
    public void GivenValuesThenAnArrayOfTheValuesIsReturned(int[] expected)
    {
        var request = new Paging(page: 1, size: 120);
        var paged = new PagedResult<int>(request, 5, expected);

        int[] actual = paged;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenNoInstanceThenAZeroSizedArrayIsReturned()
    {
        PagedResult<int>? instance = default;
        int[] value = instance;

        Assert.Empty(value);
    }
}