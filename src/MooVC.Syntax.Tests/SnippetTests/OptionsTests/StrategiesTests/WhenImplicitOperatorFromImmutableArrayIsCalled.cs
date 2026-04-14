namespace MooVC.Syntax.SnippetTests.OptionsTests.StrategiesTests;

using System.Collections.Immutable;

public sealed class WhenImplicitOperatorFromImmutableArrayIsCalled
{
    [Test]
    public async Task GivenImmutableArrayThenCreatesEquivalentStrategies()
    {
        // Arrange
        ImmutableArray<Snippet.Options.IChain> value = StrategiesTestsData.Primary;

        // Act
        Snippet.Options.Strategies result = value;

        // Assert
        _ = await Assert.That(result == value).IsTrue();
    }
}
