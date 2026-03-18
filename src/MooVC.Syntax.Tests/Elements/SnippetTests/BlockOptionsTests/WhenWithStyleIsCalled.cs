namespace MooVC.Syntax.Elements.SnippetTests.BlockOptionsTests;

public sealed class WhenWithStyleIsCalled
{
    [Test]
    public async Task GivenStyleThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.BlockOptions();

        // Act
        Snippet.BlockOptions result = options.WithStyle(Snippet.BlockOptions.StyleType.KAndR);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(options);
        _ = await Assert.That(result.Style).IsEqualTo(Snippet.BlockOptions.StyleType.KAndR);
        _ = await Assert.That(options.Style).IsEqualTo(Snippet.BlockOptions.StyleType.Allman);
    }
}