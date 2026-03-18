#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenDirectiveIsConstructed
{
    [Test]
    [Arguments(Directive.FirstPage, Directive.MinimumLimit)]
    [Arguments(Directive.FirstPage + 5, Directive.MinimumLimit + 10)]
    [Arguments(Directive.FirstPage, ushort.MaxValue)]
    [Arguments(ushort.MaxValue, Directive.MinimumLimit)]
    public void GivenAValidPageAndSizeThenThePropertiesAreSetToMatch(ushort page, ushort limit)
    {
        // Act
        Directive directive = new(Limit: limit, Page: page);

        // Assert
        directive.Limit.ShouldBe(limit);
        directive.Page.ShouldBe(page);
    }

    [Test]
    [Arguments(Directive.MinimumLimit)]
    [Arguments(Directive.MinimumLimit + 10)]
    [Arguments(ushort.MaxValue)]
    public void GivenAnInvalidPageAndAValidSizeThenThePageIsSetToTheFirstPageAndTheSizeIsSetToTheConfigured(ushort limit)
    {
        unchecked
        {
            // Arrange
            ushort page = Math.Min((ushort)(Directive.FirstPage - 1), ushort.MinValue);

            // Act
            Directive directive = new(Limit: limit, Page: page);

            // Assert
            directive.Limit.ShouldBe(limit);
            directive.Page.ShouldBe(Directive.FirstPage);
        }
    }

    [Test]
    [Arguments(Directive.FirstPage)]
    [Arguments(Directive.FirstPage + 5)]
    [Arguments(ushort.MaxValue)]
    public void GivenAnValidPageAndAnInvalidSizeThenThePageIsSetToTheConfiguredAndTheSizeIsSetToTheMinimum(ushort page)
    {
        unchecked
        {
            // Arrange
            ushort limit = Math.Min((ushort)(Directive.MinimumLimit - 1), ushort.MinValue);

            // Act
            Directive directive = new(Limit: limit, Page: page);

            // Assert
            directive.Limit.ShouldBe(Directive.MinimumLimit);
            directive.Page.ShouldBe(page);
        }
    }

    [Test]
    public void GivenBothInvalidPageAndSizeThenBothAreSetToTheirDefaultValues()
    {
        unchecked
        {
            // Arrange
            ushort limit = Math.Min((ushort)(Directive.MinimumLimit - 1), ushort.MinValue);
            ushort page = Math.Min((ushort)(Directive.FirstPage - 1), ushort.MinValue);

            // Act
            Directive directive = new(Limit: limit, Page: page);

            // Assert
            directive.Limit.ShouldBe(Directive.MinimumLimit);
            directive.Page.ShouldBe(Directive.FirstPage);
        }
    }
}
#endif