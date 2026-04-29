namespace MooVC.Syntax.SnippetTests.OptionsTests.BlocksTests.StylesTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenStyleThenReturnsExpectedString()
    {
        // Arrange
        Snippet.Options.Blocks.Styles subject = Snippet.Options.Blocks.Styles.SingleLine;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo("SingleLine");
    }
}