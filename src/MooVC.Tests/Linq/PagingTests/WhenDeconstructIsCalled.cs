namespace MooVC.Linq.PagingTests;

public sealed class WhenDeconstructIsCalled
{
    [Fact]
    public void GivenDefaultPagingThenFirstPageAndDefaultSizeAreReturned()
    {
        // Arrange
        const ushort expectedPage = Paging.FirstPage;
        const ushort expectedSize = Paging.DefaultSize;
        var paging = new Paging();

        // Act
        (ushort page, ushort size) = paging;

        // Assert
        _ = page.Should().Be(expectedPage);
        _ = size.Should().Be(expectedSize);
    }

    [Fact]
    public void GivenPagingWithCustomValuesThenThoseValuesAreReturned()
    {
        // Arrange
        const ushort expectedPage = 5;
        const ushort expectedSize = 15;
        var paging = new Paging(expectedPage, expectedSize);

        // Act
        (ushort page, ushort size) = paging;

        // Assert
        _ = page.Should().Be(expectedPage);
        _ = size.Should().Be(expectedSize);
    }

    [Fact]
    public void GivenPagingWithMaximumValuesThenThoseValuesAreReturned()
    {
        // Arrange
        const ushort expectedPage = ushort.MaxValue;
        const ushort expectedSize = ushort.MaxValue;
        var paging = new Paging(expectedPage, expectedSize);

        // Act
        (ushort page, ushort size) = paging;

        // Assert
        _ = page.Should().Be(expectedPage);
        _ = size.Should().Be(expectedSize);
    }

    [Fact]
    public void GivenPagingWithMinimumValuesThenFirstPageAndMinimumSizeAreReturned()
    {
        // Arrange
        const ushort expectedPage = Paging.FirstPage;
        const ushort expectedSize = Paging.MinimumSize;
        var paging = new Paging(0, 0);

        // Act
        (ushort page, ushort size) = paging;

        // Assert
        _ = page.Should().Be(expectedPage);
        _ = size.Should().Be(expectedSize);
    }
}