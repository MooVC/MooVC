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
        _ = isAll.Should().BeTrue();
    }

    [Fact]
    public void GivenADirectiveThatIsConfiguredForAllThenAPositiveResponseIsReturned()
    {
        // Arrange
        var directive = new Directive(size: ushort.MaxValue);

        // Act
        bool isAll = directive.IsAll;

        // Assert
        _ = isAll.Should().BeTrue();
    }

    [Fact]
    public void GivenADirectiveInstanceThatDoesNotUseAllSettingsThenANegativeResponseIsReturned()
    {
        // Arrange
        var directive = new Directive(page: 2, size: 5);

        // Act
        bool isAll = directive.IsAll;

        // Assert
        _ = isAll.Should().BeFalse();
    }
}
#endif