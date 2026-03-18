namespace MooVC.Syntax.Elements.SnippetTests.OptionsTests;

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
        await Assert.That(ReferenceEquals(result, options)).IsFalse();
        await Assert.That(result.Block).IsEqualTo(block);
        await Assert.That(options.Block).IsNotEqualTo(block);
    }
}