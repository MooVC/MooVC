namespace MooVC.Linq.PagedResultTests;

using Xunit;

public sealed class WhenPagedResultIsEnumerated
{
    [Fact]
    public void GivenValuesThenTheEnumeratedValuesAreReturnedInOrder()
    {
        int[] values = new int[] { 1, 2, 3, 4, 5 };
        Paging request = Paging.Default;
        var result = new PagedResult<int>(request, values);

        int index = 0;

        foreach (int actual in values)
        {
            int expected = result[index++];

            Assert.Equal(expected, actual);
        }

        Assert.Equal(index, values.Length);
    }
}