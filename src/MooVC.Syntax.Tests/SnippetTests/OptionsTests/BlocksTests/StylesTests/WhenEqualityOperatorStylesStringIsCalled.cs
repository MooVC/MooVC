namespace MooVC.Syntax.SnippetTests.OptionsTests.BlocksTests.StylesTests;

public sealed class WhenEqualityOperatorStylesStringIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Snippet.Options.Blocks.Styles left = Snippet.Options.Blocks.Styles.Lambda;
        string right = "Lambda";

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
