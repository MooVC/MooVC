namespace MooVC.Syntax.SnippetTests.OptionsTests.StrategiesTests;

using System.Collections.Immutable;

public sealed class WhenEqualityOperatorStrategiesImmutableArrayIsCalled
{
    [Test]
    public async Task GivenSameValueThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet.Options.Strategies(StrategiesTestsData.Primary);
        ImmutableArray<Snippet.Options.IChain> right = StrategiesTestsData.Primary;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}