#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenDeconstructIsCalled
{
    [Fact]
    public void GivenDefaultDirectiveThenFirstPageAndMinimumLimitAreReturned()
    {
        // Arrange
        const ushort expectedLimit = Directive.MinimumLimit;
        const ushort expectedPage = Directive.FirstPage;
        Directive directive = default;

        // Act
        (ushort limit, ushort page) = directive;

        // Assert
        limit.ShouldBe(expectedLimit);
        page.ShouldBe(expectedPage);
    }

    [Fact]
    public void GivenDirectiveWithCustomValuesThenThoseValuesAreReturned()
    {
        // Arrange
        const ushort expectedLimit = 15;
        const ushort expectedPage = 5;
        Directive directive = new(Limit: expectedLimit, Page: expectedPage);

        // Act
        (ushort limit, ushort page) = directive;

        // Assert
        limit.ShouldBe(expectedLimit);
        page.ShouldBe(expectedPage);
    }

    [Fact]
    public void GivenDirectiveWithMaximumValuesThenThoseValuesAreReturned()
    {
        // Arrange
        const ushort expectedLimit = ushort.MaxValue;
        const ushort expectedPage = ushort.MaxValue;
        Directive directive = new(Limit: expectedLimit, Page: expectedPage);

        // Act
        (ushort limit, ushort page) = directive;

        // Assert
        limit.ShouldBe(expectedLimit);
        page.ShouldBe(expectedPage);
    }

    [Fact]
    public void GivenDirectiveWithMinimumValuesThenFirstPageAndMinimumSizeAreReturned()
    {
        // Arrange
        const ushort expectedLimit = Directive.MinimumLimit;
        const ushort expectedPage = Directive.FirstPage;
        Directive directive = new(Limit: ushort.MinValue, Page: ushort.MinValue);

        // Act
        (ushort page, ushort size) = directive;

        // Assert
        page.ShouldBe(expectedPage);
        size.ShouldBe(expectedLimit);
    }
}
#endif