namespace MooVC.Syntax.SnippetTests.OptionsTests.StrategiesTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenSameValueThenHashesAreEqual()
    {
        // Arrange
        var left = new Snippet.Options.Strategies(StrategiesTestsData.Primary);
        var right = new Snippet.Options.Strategies(StrategiesTestsData.Primary);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsEqualTo(rightHash);
    }
}
