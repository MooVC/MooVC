#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenIsAllIsCalled
{
    [Test]
    public async Task GivenADefaultDirectiveThenAPositiveResponseIsReturned()
    {
        // Arrange
        Directive directive = default;

        // Act
        bool isAll = directive.IsAll;

        // Assert
        _ = await Assert.That(isAll).IsTrue();
    }

    [Test]
    public async Task GivenADirectiveInstanceThatDoesNotUseAllSettingsThenANegativeResponseIsReturned()
    {
        // Arrange
        Directive directive = new(Limit: 5, Page: 2);

        // Act
        bool isAll = directive.IsAll;

        // Assert
        _ = await Assert.That(isAll).IsFalse();
    }

    [Test]
    public async Task GivenADirectiveThatIsConfiguredForAllThenAPositiveResponseIsReturned()
    {
        // Arrange
        Directive directive = new(Limit: Directive.MinimumLimit, Page: Directive.FirstPage);

        // Act
        bool isAll = directive.IsAll;

        // Assert
        _ = await Assert.That(isAll).IsTrue();
    }

    [Test]
    public async Task GivenTheAllDirectiveThenAPositiveResponseIsReturned()
    {
        // Arrange
        Directive directive = Directive.All;

        // Act
        bool isAll = directive.IsAll;

        // Assert
        _ = await Assert.That(isAll).IsTrue();
    }
}
#endif