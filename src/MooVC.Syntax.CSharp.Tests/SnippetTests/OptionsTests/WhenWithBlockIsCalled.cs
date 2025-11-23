namespace MooVC.Syntax.CSharp.SnippetTests.OptionsTests;

public sealed class WhenWithBlockIsCalled
{
    [Fact]
    public void GivenBlockOptionsThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.Options();
        Snippet.BlockOptions block = options.Block
            .WithStyle(Snippet.BlockOptions.StyleType.KAndR);

        // Act
        Snippet.Options result = options.WithBlock(block);

        // Assert
        result.ShouldNotBeSameAs(options);
        result.Block.ShouldBe(block);
        options.Block.ShouldNotBe(block);
    }
}
