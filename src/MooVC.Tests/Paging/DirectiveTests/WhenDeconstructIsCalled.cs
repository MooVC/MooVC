#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenDeconstructIsCalled
{
    [Test]
    public async Task GivenDefaultDirectiveThenFirstPageAndMinimumLimitAreReturned()
    {
        // Arrange
        const ushort expectedLimit = Directive.MinimumLimit;
        const ushort expectedPage = Directive.FirstPage;
        Directive directive = default;

        // Act
        (ushort limit, ushort page) = directive;

        // Assert
        await Assert.That(limit).IsEqualTo(expectedLimit);
        await Assert.That(page).IsEqualTo(expectedPage);
    }

    [Test]
    public async Task GivenDirectiveWithCustomValuesThenThoseValuesAreReturned()
    {
        // Arrange
        const ushort expectedLimit = 15;
        const ushort expectedPage = 5;
        Directive directive = new(Limit: expectedLimit, Page: expectedPage);

        // Act
        (ushort limit, ushort page) = directive;

        // Assert
        await Assert.That(limit).IsEqualTo(expectedLimit);
        await Assert.That(page).IsEqualTo(expectedPage);
    }

    [Test]
    public async Task GivenDirectiveWithMaximumValuesThenThoseValuesAreReturned()
    {
        // Arrange
        const ushort expectedLimit = ushort.MaxValue;
        const ushort expectedPage = ushort.MaxValue;
        Directive directive = new(Limit: expectedLimit, Page: expectedPage);

        // Act
        (ushort limit, ushort page) = directive;

        // Assert
        await Assert.That(limit).IsEqualTo(expectedLimit);
        await Assert.That(page).IsEqualTo(expectedPage);
    }

    [Test]
    public async Task GivenDirectiveWithMinimumValuesThenFirstPageAndMinimumSizeAreReturned()
    {
        // Arrange
        const ushort expectedLimit = Directive.MinimumLimit;
        const ushort expectedPage = Directive.FirstPage;
        Directive directive = new(Limit: ushort.MinValue, Page: ushort.MinValue);

        // Act
        (ushort page, ushort size) = directive;

        // Assert
        await Assert.That(page).IsEqualTo(expectedPage);
        await Assert.That(size).IsEqualTo(expectedLimit);
    }
}
#endif