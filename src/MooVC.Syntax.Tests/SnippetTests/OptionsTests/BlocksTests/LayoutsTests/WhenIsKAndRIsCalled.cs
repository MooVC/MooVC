namespace MooVC.Syntax.SnippetTests.OptionsTests.BlocksTests.LayoutsTests;

public sealed class WhenIsKAndRIsCalled
{
    [Test]
    public async Task GivenAllmanThenReturnsFalse()
    {
        // Arrange
        Snippet.Options.Blocks.Layouts style = Snippet.Options.Blocks.Layouts.Allman;

        // Act
        bool result = style.IsKAndR;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenKAndRThenReturnsTrue()
    {
        // Arrange
        Snippet.Options.Blocks.Layouts style = Snippet.Options.Blocks.Layouts.KAndR;

        // Act
        bool result = style.IsKAndR;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}