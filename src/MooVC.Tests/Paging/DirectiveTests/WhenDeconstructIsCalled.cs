#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenDeconstructIsCalled
{
    [Fact]
    public void GivenDefaultDirectiveThenFirstPageAndDefaultSizeAreReturned()
    {
        // Arrange
        const ushort expectedPage = Directive.FirstPage;
        const ushort expectedSize = Directive.DefaultSize;
        Directive directive = default;

        // Act
        (ushort page, ushort size) = directive;

        // Assert
        _ = page.Should().Be(expectedPage);
        _ = size.Should().Be(expectedSize);
    }

    [Fact]
    public void GivenDirectiveWithCustomValuesThenThoseValuesAreReturned()
    {
        // Arrange
        const ushort expectedPage = 5;
        const ushort expectedSize = 15;
        var directive = new Directive(expectedPage, expectedSize);

        // Act
        (ushort page, ushort size) = directive;

        // Assert
        _ = page.Should().Be(expectedPage);
        _ = size.Should().Be(expectedSize);
    }

    [Fact]
    public void GivenDirectiveWithMaximumValuesThenThoseValuesAreReturned()
    {
        // Arrange
        const ushort expectedPage = ushort.MaxValue;
        const ushort expectedSize = ushort.MaxValue;
        var directive = new Directive(expectedPage, expectedSize);

        // Act
        (ushort page, ushort size) = directive;

        // Assert
        _ = page.Should().Be(expectedPage);
        _ = size.Should().Be(expectedSize);
    }

    [Fact]
    public void GivenDirectiveWithMinimumValuesThenFirstPageAndMinimumSizeAreReturned()
    {
        // Arrange
        const ushort expectedPage = Directive.FirstPage;
        const ushort expectedSize = Directive.MinimumSize;
        var directive = new Directive(0, 0);

        // Act
        (ushort page, ushort size) = directive;

        // Assert
        _ = page.Should().Be(expectedPage);
        _ = size.Should().Be(expectedSize);
    }
}
#endif