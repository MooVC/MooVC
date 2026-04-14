namespace MooVC.Syntax.SnippetTests.OptionsTests.BlocksTests.StylesTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenSameValueThenHashesAreEqual()
    {
        // Arrange
        Snippet.Options.Blocks.Styles left = Snippet.Options.Blocks.Styles.MultiLine;
        Snippet.Options.Blocks.Styles right = Snippet.Options.Blocks.Styles.MultiLine;

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsEqualTo(rightHash);
    }
}
