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
        _ = actual.Should().BeNull();
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
        _ = actual.Should().Equal(expected);
    }

    [Fact]
    public void GivenADirectiveThenTheSetIsFilteredIsCalled()
    {
        // Arrange
        var faker = new Faker();
        var directive = new Directive(page: 5, size: 20);

        IEnumerable<int> set = faker.Random.Digits(1000);
        IQueryable<int> queryable = set.AsQueryable();

        IEnumerable<int> expected = set
            .Skip(directive.Skip)
            .Take(directive.Size);

        // Act
        IQueryable<int>? actual = queryable.Page(directive);

        // Assert
        _ = actual.Should().Equal(expected);
    }
}
#endif