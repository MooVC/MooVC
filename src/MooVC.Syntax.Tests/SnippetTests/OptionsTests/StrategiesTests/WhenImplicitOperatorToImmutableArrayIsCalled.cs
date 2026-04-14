namespace MooVC.Syntax.SnippetTests.OptionsTests.StrategiesTests;

using System.Collections.Immutable;

public sealed class WhenImplicitOperatorToImmutableArrayIsCalled
{
    [Test]
    public async Task GivenStrategiesThenReturnsEncapsulatedValue()
    {
        // Arrange
        Snippet.Options.Strategies value = new Snippet.Options.Strategies(StrategiesTestsData.Primary);

        // Act
        ImmutableArray<Snippet.Options.IChain> result = value;

        // Assert
        _ = await Assert.That(result).IsEquivalentTo(StrategiesTestsData.Primary);
    }
}