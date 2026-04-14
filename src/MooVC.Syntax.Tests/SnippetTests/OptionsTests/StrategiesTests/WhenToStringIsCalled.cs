namespace MooVC.Syntax.SnippetTests.OptionsTests.StrategiesTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsMonifyFormattedString()
    {
        // Arrange
        var subject = new Snippet.Options.Strategies(StrategiesTestsData.Primary);

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo($"Strategies {{ {StrategiesTestsData.Primary} }}");
    }
}