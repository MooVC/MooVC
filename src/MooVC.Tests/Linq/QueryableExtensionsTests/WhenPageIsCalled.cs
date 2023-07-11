namespace MooVC.Linq.QueryableExtensionsTests;

using System.Linq;
using Bogus;
using FluentAssertions;
using Xunit;

public sealed class WhenPageIsCalled
{
    [Fact]
    public void GivenNoQueryableThenTheEmptyQueryableIsReturned()
    {
        // Arrange
        IQueryable<int>? queryable = default;
        var paging = new Paging();

        // Act
        IQueryable<int>? actual = queryable.Page(paging);

        // Assert
        _ = actual.Should().BeNull();
    }

    [Fact]
    public void GivenNoPagingThenTheQueryAbleIsReturned()
    {
        // Arrange
        var faker = new Faker();

        IQueryable<int> expected = faker
            .Random
            .Digits(1000)
            .AsQueryable();

        // Act
        IQueryable<int> actual = expected.Page(default);

        // Assert
        _ = actual.Should().Equal(expected);
    }

    [Fact]
    public void GivenPagingThenTheSetIsFilteredIsCalled()
    {
        // Arrange
        var faker = new Faker();
        var paging = new Paging(page: 5, size: 20);

        IEnumerable<int> set = faker.Random.Digits(1000);
        IQueryable<int> queryable = set.AsQueryable();
        IEnumerable<int> expected = set.Skip(paging.Skip).Take(paging.Size);

        // Act
        IQueryable<int> actual = queryable.Page(paging);

        // Assert
        _ = actual.Should().Equal(expected);
    }
}