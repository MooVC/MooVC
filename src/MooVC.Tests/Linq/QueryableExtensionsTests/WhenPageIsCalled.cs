#if NET6_0_OR_GREATER
namespace MooVC.Linq.QueryableExtensionsTests;

using MooVC.Paging;

public sealed class WhenPageIsCalled
{
    [Fact]
    public void GivenNoQueryableThenTheEmptyQueryableIsReturned()
    {
        // Arrange
        IQueryable<int>? queryable = default;
        Directive directive = default;

        // Act
        IQueryable<int>? actual = queryable.Page(directive);

        // Assert
        actual.ShouldBeNull();
    }

    [Fact]
    public void GivenAnAllDirectiveThenTheQueryAbleIsReturned()
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
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GivenADirectiveThenTheSetIsFilteredIsCalled()
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
        actual.ShouldBe(expected);
    }
}
#endif