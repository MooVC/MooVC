namespace MooVC.Syntax.SnippetTests.OptionsTests.StrategiesTests;

public sealed class WhenEqualityOperatorStrategiesStrategiesIsCalled
{
    [Test]
    public async Task GivenSameValueThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet.Options.Strategies(StrategiesTestsData.Primary);
        var right = new Snippet.Options.Strategies(StrategiesTestsData.Primary);

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}