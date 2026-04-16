namespace MooVC.Syntax.SnippetTests.OptionsTests.BlocksTests;

public sealed class WhenWithLayoutIsCalled
{
    [Test]
    public async Task GivenLayoutThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.Options.Blocks();

        // Act
        Snippet.Options.Blocks result = options.WithLayout(Snippet.Options.Blocks.Layouts.KAndR);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(options);
        _ = await Assert.That(result.Layout).IsEqualTo(Snippet.Options.Blocks.Layouts.KAndR);
        _ = await Assert.That(options.Layout).IsEqualTo(Snippet.Options.Blocks.Layouts.Allman);
    }
}