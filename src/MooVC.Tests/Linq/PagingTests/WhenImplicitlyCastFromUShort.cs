namespace MooVC.Linq.PagingTests;

public sealed class WhenImplicitlyCastFromUShort
{
    [Theory]
    [InlineData(Paging.MinimumSize, ushort.MinValue)]
    [InlineData(5, 5)]
    [InlineData(ushort.MaxValue, ushort.MaxValue)]
    public void GivenAValueThenAnInstanceIsReturnedWithTheExpectedSize(ushort expected, ushort size)
    {
        // Act
        Paging paging = size;

        // Assert
        _ = paging.Page.Should().Be(Paging.FirstPage);
        _ = paging.Size.Should().Be(expected);
    }

    [Fact]
    public void GivenASizeOfDefaultThenDefaultIsReturned()
    {
        // Act
        Paging paging = Paging.DefaultSize;

        // Assert
        _ = paging.Should().BeSameAs(Paging.Default);
    }

    [Fact]
    public void GivenASizeOfOneThenOneIsReturned()
    {
        // Act
        Paging paging = 1;

        // Assert
        _ = paging.Should().BeSameAs(Paging.One);
    }

    [Fact]
    public void GivenSizeOfMaxThenNoneIsReturned()
    {
        // Act
        Paging paging = ushort.MaxValue;

        // Assert
        _ = paging.Should().BeSameAs(Paging.None);
    }
}