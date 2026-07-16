namespace MooVC.Syntax.SnippetTests.OptionsTests.BlocksTests.StylesTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenSameValueThenReturnsTrue()
    {
        // Arrange
        Snippet.Options.Blocks.Styles subject = Snippet.Options.Blocks.Styles.MultiLine;
        object other = Snippet.Options.Blocks.Styles.MultiLine;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}