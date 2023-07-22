namespace MooVC.Linq.PagingTests;

using FluentAssertions;
using Xunit;

public sealed class WhenPreviousIsCalled
{
    [Theory]
    [InlineData(ushort.MinValue, 1, 9)]
    [InlineData(1, 1, 25)]
    [InlineData(2, 1, 1)]
    [InlineData(5, 4, 10)]
    [InlineData(ushort.MaxValue, 65534, 5)]
    public void GivenAPageThenPagingForThePreviousDecrementIsReturned(ushort current, ushort expected, ushort size)
    {
        // Arrange
        var page = new Paging(page: current, size: size);

        // Act
        Paging previous = page.Previous();

        // Assert
        _ = previous.Page.Should().Be(expected);
        _ = previous.Size.Should().Be(size);
    }

    [Fact]
    public void GivenMinimumPageThenPagingForTheSamePageIsReturned()
    {
        // Arrange
        ushort current = Paging.FirstPage;
        ushort size = 10;
        var page = new Paging(page: current, size: size);

        // Act
        Paging previous = page.Previous();

        // Assert
        _ = previous.Should().BeSameAs(page);
    }
}