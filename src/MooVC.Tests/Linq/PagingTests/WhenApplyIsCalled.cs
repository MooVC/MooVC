namespace MooVC.Linq.PagingTests
{
    using System.Linq;
    using Xunit;

    public sealed class WhenApplyIsCalled
    {
        [Theory]
        [InlineData(1, 5, new int[] { 0, 1, 2, 3, 4 })]
        [InlineData(2, 1, new int[] { 1 })]
        [InlineData(10, 2, new int[] { 18, 19 })]
        public void GivenAQueryableThenTheResultsArePagedAsConfigured(ushort page, ushort size, int[] expected)
        {
            var paging = new Paging(page: page, size: size);
            IQueryable<int> queryable = Enumerable.Range(0, 20).AsQueryable();

            int[] actual = paging.Apply(queryable).ToArray();

            Assert.Equal(expected, actual);
        }
    }
}