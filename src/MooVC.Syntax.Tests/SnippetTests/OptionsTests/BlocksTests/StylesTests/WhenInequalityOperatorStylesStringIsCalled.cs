namespace MooVC.Syntax.SnippetTests.OptionsTests.BlocksTests.StylesTests;

public sealed class WhenInequalityOperatorStylesStringIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Snippet.Options.Blocks.Styles left = Snippet.Options.Blocks.Styles.Lambda;
        string right = "SingleLine";

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
