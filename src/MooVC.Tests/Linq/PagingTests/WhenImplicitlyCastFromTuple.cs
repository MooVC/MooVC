namespace MooVC.Linq.PagingTests;

using FluentAssertions;
using Xunit;

public sealed class WhenImplicitlyCastFromTuple
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(5, 4)]
    [InlineData(ushort.MaxValue, Paging.MinimumSize)]
    [InlineData(Paging.FirstPage, ushort.MaxValue)]
    [InlineData(ushort.MaxValue, ushort.MaxValue)]
    public void GivenAValueThenAnInstanceIsReturnedWithTheExpectedSize(ushort page, ushort size)
    {
        // Act
        Paging paging = (page, size);

        // Assert
        _ = paging.Page.Should().Be(page);
        _ = paging.Size.Should().Be(size);
    }

    [Fact]
    public void GivenAPageOfOneAndASizeOfDefaultThenDefaultIsReturned()
    {
        // Act
        Paging paging = (1, Paging.DefaultSize);

        // Assert
        _ = paging.Should().BeSameAs(Paging.Default);
    }

    [Fact]
    public void GivenAPageOfOneAndASizeOfOneThenOneIsReturned()
    {
        // Act
        Paging paging = (1, 1);

        // Assert
        _ = paging.Should().BeSameAs(Paging.One);
    }

    [Fact]
    public void GivenAPageOfOneAndASizeOfMaxThenNoneIsReturned()
    {
        // Act
        Paging paging = (1, ushort.MaxValue);

        // Assert
        _ = paging.Should().BeSameAs(Paging.None);
    }
}