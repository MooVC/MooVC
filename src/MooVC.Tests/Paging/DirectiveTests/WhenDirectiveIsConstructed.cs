#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

using System.Collections.Generic;

public sealed class WhenDirectiveIsConstructed
{
    [Theory]
    [InlineData(Directive.FirstPage, Directive.MinimumLimit)]
    [InlineData(Directive.FirstPage + 5, Directive.MinimumLimit + 10)]
    [InlineData(Directive.FirstPage, ushort.MaxValue)]
    [InlineData(ushort.MaxValue, Directive.MinimumLimit)]
    public void GivenAValidPageAndSizeThenThePropertiesAreSetToMatch(ushort page, ushort limit)
    {
        // Act
        Directive directive = new(Limit: limit, Page: page);

        // Assert
        directive.Limit.ShouldBe(limit);
        directive.Page.ShouldBe(page);
    }

    [Theory]
    [InlineData(Directive.MinimumLimit)]
    [InlineData(Directive.MinimumLimit + 10)]
    [InlineData(ushort.MaxValue)]
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

    [Theory]
    [InlineData(Directive.FirstPage)]
    [InlineData(Directive.FirstPage + 5)]
    [InlineData(ushort.MaxValue)]
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

    [Fact]
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