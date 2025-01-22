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
        _ = result.Directive.Should().Be(Directive.All);
        _ = result.Total.Should().Be((ulong)expected.LongLength);
        _ = result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, 1, 3, 6, new[] { 1, 2, 3, 4, 5, 6 })]
    [InlineData(new[] { 3, 4 }, 2, 2, 6, new[] { 1, 2, 3, 4, 5, 6 })]
    [InlineData(new int[0], 3, 2, 4, new[] { 1, 2, 3, 4 })]
    public void GivenADirectiveThenTheExpectedPageIsReturned(int[] expected, ushort page, ushort size, ulong total, int[] values)
    {
        // Arrange
        var directive = new Directive(page: page, size: size);
        IQueryable<int> query = values.AsQueryable();

        // Act
        var result = query.ToPage(directive);

        // Assert
        _ = result.Directive.Should().Be(directive);
        _ = result.Total.Should().Be(total);
        _ = result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void GivenNullQueryThenAnEmptyPageIsReturned()
    {
        // Arrange
        IQueryable<int>? query = default;
        var directive = new Directive(page: 1, size: 1);

        // Act
        var result = query.ToPage(directive);

        // Assert
        _ = result.Directive.Should().Be(directive);
        _ = result.Total.Should().Be(ulong.MinValue);
    }
}
#endif