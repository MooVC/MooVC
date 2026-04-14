namespace MooVC.Syntax.SnippetTests.OptionsTests.StrategiesTests;

using System.Collections.Immutable;

public sealed class WhenInequalityOperatorStrategiesImmutableArrayIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet.Options.Strategies(StrategiesTestsData.Primary);
        ImmutableArray<Snippet.Options.IChain> right = StrategiesTestsData.Alternate;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}