namespace MooVC.Syntax.SnippetTests.OptionsTests.BlocksTests.StylesTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public async Task GivenStringThenCreatesEquivalentStyle()
    {
        // Arrange
        string value = "MultiLine";

        // Act
        Snippet.Options.Blocks.Styles result = value;

        // Assert
        _ = await Assert.That(result == value).IsTrue();
    }
}
