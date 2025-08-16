#if NET6_0_OR_GREATER
namespace MooVC.Linq.QueryableExtensionsTests;

using MooVC.Paging;

public sealed class WhenToPageIsCalled
{
    [Theory]
    [InlineData(new[] { 1, 2, 3 })]
    [InlineData(new int[0])]
    public void GivenAnAllDirectiveThenAllResultsAreReturned(int[] expected)
    {
        // Arrange
        IQueryable<int> query = expected.AsQueryable();

        // Act
        var result = query.ToPage(Directive.All);

        // Assert
        result.Directive.ShouldBe(Directive.All);
        result.Total.ShouldBe((ulong)expected.LongLength);
        result.ShouldBe(expected);
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, 0, 3, 6, new[] { 1, 2, 3, 4, 5, 6 })]
    [InlineData(new[] { 3, 4 }, 1, 2, 6, new[] { 1, 2, 3, 4, 5, 6 })]
    [InlineData(new int[0], 2, 2, 4, new[] { 1, 2, 3, 4 })]
    public void GivenADirectiveThenTheExpectedPageIsReturned(int[] expected, ushort page, ushort limit, ulong total, int[] values)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: page);
        IQueryable<int> query = values.AsQueryable();

        // Act
        var result = query.ToPage(directive);

        // Assert
        result.Directive.ShouldBe(directive);
        result.Total.ShouldBe(total);
        result.ShouldBe(expected);
    }

    [Fact]
    public void GivenNullQueryThenAnEmptyPageIsReturned()
    {
        // Arrange
        IQueryable<int>? query = default;
        Directive directive = new(Limit: 1, Page: 1);

        // Act
        var result = query.ToPage(directive);

        // Assert
        result.Directive.ShouldBe(directive);
        result.Total.ShouldBe(default(ulong?));
    }
}
#endif