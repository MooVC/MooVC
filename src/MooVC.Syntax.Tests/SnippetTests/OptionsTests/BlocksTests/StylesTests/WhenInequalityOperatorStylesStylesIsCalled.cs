namespace MooVC.Syntax.SnippetTests.OptionsTests.BlocksTests.StylesTests;

public sealed class WhenInequalityOperatorStylesStylesIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Snippet.Options.Blocks.Styles left = Snippet.Options.Blocks.Styles.MultiLine;
        Snippet.Options.Blocks.Styles right = Snippet.Options.Blocks.Styles.SingleLine;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
