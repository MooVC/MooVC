#if NET6_0_OR_GREATER
namespace MooVC.Linq.QueryableExtensionsTests;

using MooVC.Paging;

public sealed class WhenToPageIsCalled
{
    [Test]
    [Arguments(new[] { 1, 2, 3 })]
    [Arguments(new int[0])]
    public async Task GivenAnAllDirectiveThenAllResultsAreReturned(int[] expected)
    {
        // Arrange
        IQueryable<int> query = expected.AsQueryable();

        // Act
        var result = query.ToPage(Directive.All);

        // Assert
        _ = await Assert.That(result.Directive).IsEqualTo(Directive.All);
        _ = await Assert.That(result.Total).IsEqualTo((ulong)expected.LongLength);
        _ = await Assert.That(result).IsEquivalentTo(expected);
    }

    [Test]
    [Arguments(new[] { 1, 2, 3 }, 0, 3, 6, new[] { 1, 2, 3, 4, 5, 6 })]
    [Arguments(new[] { 3, 4 }, 1, 2, 6, new[] { 1, 2, 3, 4, 5, 6 })]
    [Arguments(new int[0], 2, 2, 4, new[] { 1, 2, 3, 4 })]
    public async Task GivenADirectiveThenTheExpectedPageIsReturned(int[] expected, ushort page, ushort limit, ulong total, int[] values)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: page);
        IQueryable<int> query = values.AsQueryable();

        // Act
        var result = query.ToPage(directive);

        // Assert
        _ = await Assert.That(result.Directive).IsEqualTo(directive);
        _ = await Assert.That(result.Total).IsEqualTo(total);
        _ = await Assert.That(result).IsEquivalentTo(expected);
    }

    [Test]
    public async Task GivenNullQueryThenAnEmptyPageIsReturned()
    {
        // Arrange
        IQueryable<int>? query = default;
        Directive directive = new(Limit: 1, Page: 1);

        // Act
        var result = query.ToPage(directive);

        // Assert
        _ = await Assert.That(result.Directive).IsEqualTo(directive);
        _ = await Assert.That(result.Total).IsEqualTo(default);
    }
}
#endif