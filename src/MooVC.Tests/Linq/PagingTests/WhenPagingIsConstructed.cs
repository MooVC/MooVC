namespace MooVC.Linq.PagingTests;

using System;
using FluentAssertions;
using Xunit;

public sealed class WhenPagingIsConstructed
{
    [Theory]
    [InlineData(Paging.FirstPage, Paging.MinimumSize)]
    [InlineData(Paging.FirstPage + 5, Paging.MinimumSize + 10)]
    [InlineData(Paging.FirstPage, ushort.MaxValue)]
    [InlineData(ushort.MaxValue, Paging.MinimumSize)]
    public void GivenAValidPageAndSizeThenThePropertiesAreSetToMatch(ushort page, ushort size)
    {
        // Act
        var paging = new Paging(page: page, size: size);

        // Assert
        _ = paging.Page.Should().Be(page);
        _ = paging.Size.Should().Be(size);
    }

    [Theory]
    [InlineData(Paging.MinimumSize)]
    [InlineData(Paging.MinimumSize + 10)]
    [InlineData(ushort.MaxValue)]
    public void GivenAnInvalidPageAndAValidSizeThenThePageIsSetToTheFirstPageAndTheSizeIsSetToTheConfigured(ushort size)
    {
        // Arrange
        ushort page = Math.Min((ushort)(Paging.FirstPage - 1), ushort.MinValue);

        // Act
        var paging = new Paging(page: page, size: size);

        // Assert
        _ = paging.Page.Should().Be(Paging.FirstPage);
        _ = paging.Size.Should().Be(size);
    }

    [Theory]
    [InlineData(Paging.FirstPage)]
    [InlineData(Paging.FirstPage + 5)]
    [InlineData(ushort.MaxValue)]
    public void GivenAnValidPageAndAnInvalidSizeThenThePageIsSetToTheConfiguredAndTheSizeIsSetToTheMinimum(ushort page)
    {
        // Arrange
        ushort size = Math.Min((ushort)(Paging.MinimumSize - 1), ushort.MinValue);

        // Act
        var paging = new Paging(page: page, size: size);

        // Assert
        _ = paging.Page.Should().Be(page);
        _ = paging.Size.Should().Be(Paging.MinimumSize);
    }

    [Fact]
    public void GivenBothInvalidPageAndSizeThenBothAreSetToTheirDefaultValues()
    {
        // Arrange
        ushort page = Math.Min((ushort)(Paging.FirstPage - 1), ushort.MinValue);
        ushort size = Math.Min((ushort)(Paging.MinimumSize - 1), ushort.MinValue);

        // Act
        var paging = new Paging(page: page, size: size);

        // Assert
        _ = paging.Page.Should().Be(Paging.FirstPage);
        _ = paging.Size.Should().Be(Paging.MinimumSize);
    }
}