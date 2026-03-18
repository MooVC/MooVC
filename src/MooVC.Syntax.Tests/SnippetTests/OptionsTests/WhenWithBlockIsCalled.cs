namespace MooVC.Syntax.SnippetTests.OptionsTests;

public sealed class WhenWithBlockIsCalled
{
    [Test]
    public async Task GivenBlockOptionsThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.Options();

        Snippet.BlockOptions block = options.Block
            .WithStyle(Snippet.BlockOptions.StyleType.KAndR);

        // Act
        Snippet.Options result = options.WithBlock(block);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(options);
        _ = await Assert.That(result.Block).IsEqualTo(block);
        _ = await Assert.That(options.Block).IsNotEqualTo(block);
    }
}