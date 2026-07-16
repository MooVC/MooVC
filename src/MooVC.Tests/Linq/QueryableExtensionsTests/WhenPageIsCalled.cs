#if NET6_0_OR_GREATER
namespace MooVC.Linq.QueryableExtensionsTests;

using MooVC.Paging;

public sealed class WhenPageIsCalled
{
    [Test]
    public async Task GivenADirectiveThenTheSetIsFilteredIsCalled()
    {
        // Arrange
        var faker = new Faker();
        Directive directive = new(Limit: 20, Page: 5);

        IEnumerable<int> set = faker.Random.Digits(1000);
        IQueryable<int> queryable = set.AsQueryable();

        IEnumerable<int> expected = set
            .Skip(directive.Skip)
            .Take(directive.Limit);

        // Act
        IQueryable<int>? actual = queryable.Page(directive);

        // Assert
        _ = await Assert.That(actual).IsEquivalentTo(expected);
    }

    [Test]
    public async Task GivenAnAllDirectiveThenTheQueryAbleIsReturned()
    {
        // Arrange
        var faker = new Faker();

        IQueryable<int> expected = faker
            .Random
            .Digits(1000)
            .AsQueryable();

        // Act
        IQueryable<int>? actual = expected.Page(Directive.All);

        // Assert
        _ = await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenNoQueryableThenTheEmptyQueryableIsReturned()
    {
        // Arrange
        IQueryable<int>? queryable = default;
        Directive directive = default;

        // Act
        IQueryable<int>? actual = queryable.Page(directive);

        // Assert
        _ = await Assert.That(actual).IsNull();
    }
}
#endif