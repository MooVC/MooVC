namespace MooVC.Syntax.SnippetTests.OptionsTests;

public sealed class WhenWithBlockIsCalled
{
    [Test]
    public async Task GivenBlockOptionsThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.Options();

        Snippet.Options.Blocks block = options.Block
            .WithLayout(Snippet.Options.Blocks.Layouts.KAndR);

        // Act
        Snippet.Options result = options.WithBlock(block);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(options);
        _ = await Assert.That(result.Block).IsEqualTo(block);
        _ = await Assert.That(options.Block).IsNotEqualTo(block);
    }
}