namespace MooVC.Linq.PagingTests;

using FluentAssertions;
using Xunit;

public sealed class WhenNextIsCalled
{
    [Theory]
    [InlineData(0, 2, 25)]
    [InlineData(1, 2, 1)]
    [InlineData(4, 5, 10)]
    [InlineData(ushort.MaxValue - 1, ushort.MaxValue, 5)]
    public void GivenAPageThenPagingForTheNextIncrementIsReturned(ushort current, ushort expected, ushort size)
    {
        // Arrange
        var page = new Paging(page: current, size: size);

        // Act
        Paging next = page.Next();

        // Assert
        _ = next.Page.Should().Be(expected);
        _ = next.Size.Should().Be(size);
    }

    [Fact]
    public void GivenAPageAtMaxThenTheSamePagingIsReturned()
    {
        // Arrange
        var page = new Paging(page: ushort.MaxValue, size: 10);

        // Act
        Paging next = page.Next();

        // Assert
        _ = next.Should().BeSameAs(page);
    }
}