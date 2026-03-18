#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenDirectiveIsConstructed
{
    [Test]
    [Arguments(Directive.FirstPage, Directive.MinimumLimit)]
    [Arguments(Directive.FirstPage + 5, Directive.MinimumLimit + 10)]
    [Arguments(Directive.FirstPage, ushort.MaxValue)]
    [Arguments(ushort.MaxValue, Directive.MinimumLimit)]
    public async Task GivenAValidPageAndSizeThenThePropertiesAreSetToMatch(ushort page, ushort limit)
    {
        // Act
        Directive directive = new(Limit: limit, Page: page);

        // Assert
        _ = await Assert.That(directive.Limit).IsEqualTo(limit);
        _ = await Assert.That(directive.Page).IsEqualTo(page);
    }

    [Test]
    [Arguments(Directive.MinimumLimit)]
    [Arguments(Directive.MinimumLimit + 10)]
    [Arguments(ushort.MaxValue)]
    public async Task GivenAnInvalidPageAndAValidSizeThenThePageIsSetToTheFirstPageAndTheSizeIsSetToTheConfigured(ushort limit)
    {
        unchecked
        {
            // Arrange
            ushort page = Math.Min((ushort)(Directive.FirstPage - 1), ushort.MinValue);

            // Act
            Directive directive = new(Limit: limit, Page: page);

            // Assert
            _ = await Assert.That(directive.Limit).IsEqualTo(limit);
            _ = await Assert.That(directive.Page).IsEqualTo(Directive.FirstPage);
        }
    }

    [Test]
    [Arguments(Directive.FirstPage)]
    [Arguments(Directive.FirstPage + 5)]
    [Arguments(ushort.MaxValue)]
    public async Task GivenAnValidPageAndAnInvalidSizeThenThePageIsSetToTheConfiguredAndTheSizeIsSetToTheMinimum(ushort page)
    {
        unchecked
        {
            // Arrange
            ushort limit = Math.Min((ushort)(Directive.MinimumLimit - 1), ushort.MinValue);

            // Act
            Directive directive = new(Limit: limit, Page: page);

            // Assert
            _ = await Assert.That(directive.Limit).IsEqualTo(Directive.MinimumLimit);
            _ = await Assert.That(directive.Page).IsEqualTo(page);
        }
    }

    [Test]
    public async Task GivenBothInvalidPageAndSizeThenBothAreSetToTheirDefaultValues()
    {
        unchecked
        {
            // Arrange
            ushort limit = Math.Min((ushort)(Directive.MinimumLimit - 1), ushort.MinValue);
            ushort page = Math.Min((ushort)(Directive.FirstPage - 1), ushort.MinValue);

            // Act
            Directive directive = new(Limit: limit, Page: page);

            // Assert
            _ = await Assert.That(directive.Limit).IsEqualTo(Directive.MinimumLimit);
            _ = await Assert.That(directive.Page).IsEqualTo(Directive.FirstPage);
        }
    }
}
#endif