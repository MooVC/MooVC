#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenImplicitlyCastFromUShort
{
    [Test]
    [Arguments(Directive.MinimumLimit, ushort.MinValue)]
    [Arguments(5, 5)]
    [Arguments(ushort.MaxValue, ushort.MaxValue)]
    public void GivenAValueThenAnInstanceIsReturnedWithTheExpectedPage(ushort expected, ushort page)
    {
        // Act
        Directive directive = page;

        // Assert
        directive.Limit.ShouldBe(Directive.DefaultLimit);
        directive.Page.ShouldBe(expected);
    }
}
#endif