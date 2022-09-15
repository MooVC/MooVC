namespace MooVC.Linq.PagedResultTests;

using Xunit;

public sealed class WhenPagedResultIsIndexed
{
    [Theory]
    [InlineData(2, 1, new[] { 1, 2, 3 })]
    [InlineData(1, 2, new[] { 3, 2, 1 })]
    [InlineData(5, 0, new[] { 5, 4, 3 })]
    public void GivenAnIndexThenTheElementAtThatIndexIsReturned(int expected, int index, int[] values)
    {
        Paging request = Paging.Default;
        var result = new PagedResult<int>(request, values);

        int actual = result[index];

        Assert.Equal(expected, actual);
    }
}