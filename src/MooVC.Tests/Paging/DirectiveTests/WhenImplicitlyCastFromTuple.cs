#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenImplicitlyCastFromTuple
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(5, 4)]
    [InlineData(ushort.MaxValue, Directive.MinimumSize)]
    [InlineData(Directive.FirstPage, ushort.MaxValue)]
    [InlineData(ushort.MaxValue, ushort.MaxValue)]
    public void GivenAValueThenAnInstanceIsReturnedWithTheExpectedSize(ushort page, ushort size)
    {
        // Act
        Directive directive = (page, size);

        // Assert
        _ = directive.Page.Should().Be(page);
        _ = directive.Size.Should().Be(size);
    }

    [Fact]
    public void GivenAPageOfOneAndASizeOfDefaultThenDefaultIsReturned()
    {
        // Act
        Directive directive = (1, Directive.DefaultSize);

        // Assert
        _ = directive.Should().Be(default);
    }

    [Fact]
    public void GivenAPageOfOneAndASizeOfMaxThenAllIsReturned()
    {
        // Act
        Directive directive = (1, ushort.MaxValue);

        // Assert
        _ = directive.Should().Be(Directive.All);
    }
}
#endif