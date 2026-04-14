namespace MooVC.Syntax.SnippetTests.OptionsTests.BlocksTests.StylesTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenStyleThenReturnsUnderlyingValue()
    {
        // Arrange
        Snippet.Options.Blocks.Styles value = Snippet.Options.Blocks.Styles.Lambda;

        // Act
        string result = value;

        // Assert
        _ = await Assert.That(result).IsEqualTo("Lambda");
    }
}
