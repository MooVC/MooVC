namespace MooVC.Syntax.SnippetTests.OptionsTests.StrategiesTests;

public sealed class WhenEqualsStrategiesIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet.Options.Strategies(StrategiesTestsData.Primary);
        var right = new Snippet.Options.Strategies(StrategiesTestsData.Alternate);

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}
