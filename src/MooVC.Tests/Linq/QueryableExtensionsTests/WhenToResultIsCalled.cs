namespace MooVC.Linq.QueryableExtensionsTests;

public sealed class WhenToResultIsCalled
{
    [Theory]
    [InlineData(new[] { 1, 2, 3 })]
    [InlineData(new int[0])]
    public void GivenNoPagingThenAnEmptyResultIsReturned(int[] expected)
    {
        // Arrange
        IQueryable<int> query = expected.AsQueryable();

        // Act
        PagedResult<int> result = query.ToResult(default);

        // Assert
        _ = result.Request.Should().BeEquivalentTo(Paging.None);
        _ = result.Total.Should().Be((ulong)expected.LongLength);
        _ = result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, 1, 3, 6, new[] { 1, 2, 3, 4, 5, 6 })]
    [InlineData(new[] { 3, 4 }, 2, 2, 6, new[] { 1, 2, 3, 4, 5, 6 })]
    [InlineData(new int[0], 3, 2, 4, new[] { 1, 2, 3, 4 })]
    public void GivenPagingThenAnEmptyResultIsReturned(int[] expected, ushort page, ushort size, ulong total, int[] values)
    {
        // Arrange
        var request = new Paging(page: page, size: size);
        IQueryable<int> query = values.AsQueryable();

        // Act
        PagedResult<int> result = query.ToResult(request);

        // Assert
        _ = result.Request.Should().BeEquivalentTo(request);
        _ = result.Total.Should().Be(total);
        _ = result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void GivenNullQueryThenAnEmptyResultIsReturned()
    {
        // Arrange
        IQueryable<int>? query = default;
        var request = new Paging(page: 1, size: 1);

        // Act
        PagedResult<int> result = query.ToResult(request);

        // Assert
        _ = result.Request.Should().BeSameAs(request);
        _ = result.Total.Should().Be(ulong.MinValue);
    }
}