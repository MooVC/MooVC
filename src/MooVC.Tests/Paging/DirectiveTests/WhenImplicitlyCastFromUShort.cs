#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenImplicitlyCastFromUShort
{
    [Theory]
    [InlineData(Directive.MinimumSize, ushort.MinValue)]
    [InlineData(5, 5)]
    [InlineData(ushort.MaxValue, ushort.MaxValue)]
    public void GivenAValueThenAnInstanceIsReturnedWithTheExpectedSize(ushort expected, ushort size)
    {
        // Act
        Directive directive = size;

        // Assert
        _ = directive.Page.Should().Be(Directive.FirstPage);
        _ = directive.Size.Should().Be(expected);
    }

    [Fact]
    public void GivenASizeOfDefaultThenDefaultIsReturned()
    {
        // Act
        Directive directive = Directive.DefaultSize;

        // Assert
        _ = directive.Should().Be(default);
    }

    [Fact]
    public void GivenSizeOfMaxThenAllIsReturned()
    {
        // Act
        Directive directive = ushort.MaxValue;

        // Assert
        _ = directive.Should().Be(Directive.All);
    }
}
#endif