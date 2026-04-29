namespace MooVC.Syntax.SnippetTests.OptionsTests.BlocksTests.StyleTests;

public sealed class WhenIsAllmanIsCalled
{
    [Test]
    public async Task GivenAllmanThenReturnsTrue()
    {
        // Arrange
        Snippet.Options.Blocks.Layouts style = Snippet.Options.Blocks.Layouts.Allman;

        // Act
        bool result = style.IsAllman;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenKAndRThenReturnsFalse()
    {
        // Arrange
        Snippet.Options.Blocks.Layouts style = Snippet.Options.Blocks.Layouts.KAndR;

        // Act
        bool result = style.IsAllman;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}