namespace MooVC.Syntax.SnippetTests.OptionsTests.BlocksTests.StylesTests;

public sealed class WhenEqualityOperatorStylesStylesIsCalled
{
    [Test]
    public async Task GivenSameValueThenReturnsTrue()
    {
        // Arrange
        Snippet.Options.Blocks.Styles left = Snippet.Options.Blocks.Styles.MultiLine;
        Snippet.Options.Blocks.Styles right = Snippet.Options.Blocks.Styles.MultiLine;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}
