namespace MooVC.Syntax.CSharp.SnippetTests.BlockOptionsTests;

public sealed class WhenWithStyleIsCalled
{
    [Fact]
    public void GivenStyleThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.BlockOptions();

        // Act
        Snippet.BlockOptions result = options.WithStyle(Snippet.BlockOptions.StyleType.KAndR);

        // Assert
        result.ShouldNotBeSameAs(options);
        result.Style.ShouldBe(Snippet.BlockOptions.StyleType.KAndR);
        options.Style.ShouldBe(Snippet.BlockOptions.StyleType.Allman);
    }
}
