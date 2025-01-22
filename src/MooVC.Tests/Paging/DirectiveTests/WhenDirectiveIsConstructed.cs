#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenDirectiveIsConstructed
{
    [Theory]
    [InlineData(Directive.FirstPage, Directive.MinimumSize)]
    [InlineData(Directive.FirstPage + 5, Directive.MinimumSize + 10)]
    [InlineData(Directive.FirstPage, ushort.MaxValue)]
    [InlineData(ushort.MaxValue, Directive.MinimumSize)]
    public void GivenAValidPageAndSizeThenThePropertiesAreSetToMatch(ushort page, ushort size)
    {
        // Act
        var directive = new Directive(page: page, size: size);

        // Assert
        _ = directive.Page.Should().Be(page);
        _ = directive.Size.Should().Be(size);
    }

    [Theory]
    [InlineData(Directive.MinimumSize)]
    [InlineData(Directive.MinimumSize + 10)]
    [InlineData(ushort.MaxValue)]
    public void GivenAnInvalidPageAndAValidSizeThenThePageIsSetToTheFirstPageAndTheSizeIsSetToTheConfigured(ushort size)
    {
        // Arrange
        ushort page = Math.Min((ushort)(Directive.FirstPage - 1), ushort.MinValue);

        // Act
        var directive = new Directive(page: page, size: size);

        // Assert
        _ = directive.Page.Should().Be(Directive.FirstPage);
        _ = directive.Size.Should().Be(size);
    }

    [Theory]
    [InlineData(Directive.FirstPage)]
    [InlineData(Directive.FirstPage + 5)]
    [InlineData(ushort.MaxValue)]
    public void GivenAnValidPageAndAnInvalidSizeThenThePageIsSetToTheConfiguredAndTheSizeIsSetToTheMinimum(ushort page)
    {
        // Arrange
        ushort size = Math.Min((ushort)(Directive.MinimumSize - 1), ushort.MinValue);

        // Act
        var directive = new Directive(page: page, size: size);

        // Assert
        _ = directive.Page.Should().Be(page);
        _ = directive.Size.Should().Be(Directive.MinimumSize);
    }

    [Fact]
    public void GivenBothInvalidPageAndSizeThenBothAreSetToTheirDefaultValues()
    {
        // Arrange
        ushort page = Math.Min((ushort)(Directive.FirstPage - 1), ushort.MinValue);
        ushort size = Math.Min((ushort)(Directive.MinimumSize - 1), ushort.MinValue);

        // Act
        var directive = new Directive(page: page, size: size);

        // Assert
        _ = directive.Page.Should().Be(Directive.FirstPage);
        _ = directive.Size.Should().Be(Directive.MinimumSize);
    }
}
#endif