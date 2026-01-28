#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenIsAllIsCalled
{
    [Fact]
    public void GivenTheAllDirectiveThenAPositiveResponseIsReturned()
    {
        // Arrange
        Directive directive = Directive.All;

        // Act
        bool isAll = directive.IsAll;

        // Assert
        isAll.ShouldBeTrue();
    }

    [Fact]
    public void GivenADefaultDirectiveThenAPositiveResponseIsReturned()
    {
        // Arrange
        Directive directive = default;

        // Act
        bool isAll = directive.IsAll;

        // Assert
        isAll.ShouldBeTrue();
    }

    [Fact]
    public void GivenADirectiveThatIsConfiguredForAllThenAPositiveResponseIsReturned()
    {
        // Arrange
        Directive directive = new(Limit: Directive.MinimumLimit, Page: Directive.FirstPage);

        // Act
        bool isAll = directive.IsAll;

        // Assert
        isAll.ShouldBeTrue();
    }

    [Fact]
    public void GivenADirectiveInstanceThatDoesNotUseAllSettingsThenANegativeResponseIsReturned()
    {
        // Arrange
        Directive directive = new(Limit: 5, Page: 2);

        // Act
        bool isAll = directive.IsAll;

        // Assert
        isAll.ShouldBeFalse();
    }
}
#endif