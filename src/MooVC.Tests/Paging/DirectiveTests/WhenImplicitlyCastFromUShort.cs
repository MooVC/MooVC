#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenImplicitlyCastFromUShort
{
    [Theory]
    [InlineData(Directive.MinimumLimit, ushort.MinValue)]
    [InlineData(5, 5)]
    [InlineData(ushort.MaxValue, ushort.MaxValue)]
    public void GivenAValueThenAnInstanceIsReturnedWithTheExpectedPage(ushort expected, ushort page)
    {
        // Act
        Directive directive = page;

        // Assert
        _ = directive.Limit.Should().Be(Directive.DefaultLimit);
        _ = directive.Page.Should().Be(expected);
    }
}
#endif