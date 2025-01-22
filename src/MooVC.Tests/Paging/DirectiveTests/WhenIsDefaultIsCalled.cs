#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenIsDefaultIsCalled
{
    [Fact]
    public void GivenTheDirectiveDefaultThenAPositiveResponseIsReturned()
    {
        // Arrange
        Directive directive = default;

        // Act
        bool isDefault = directive.IsDefault;

        // Assert
        _ = isDefault.Should().BeTrue();
    }

    [Fact]
    public void GivenADirectiveThatIsConfiguredForDefaultThenAPositiveResponseIsReturned()
    {
        // Arrange
        var directive = new Directive(page: Directive.FirstPage, size: Directive.DefaultSize);

        // Act
        bool isDefault = directive.IsDefault;

        // Assert
        _ = isDefault.Should().BeTrue();
    }

    [Fact]
    public void GivenADirectiveInstanceThatDoesNotUseDefaultSettingsThenANegativeResponseIsReturned()
    {
        // Arrange
        var directive = new Directive(page: 2, size: 5);

        // Act
        bool isDefault = directive.IsDefault;

        // Assert
        _ = isDefault.Should().BeFalse();
    }
}
#endif