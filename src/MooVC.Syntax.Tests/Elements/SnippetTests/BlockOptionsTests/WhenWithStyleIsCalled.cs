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
        await Assert.That(ReferenceEquals(result, options)).IsFalse();
        await Assert.That(result.Style).IsEqualTo(Snippet.BlockOptions.StyleType.KAndR);
        await Assert.That(options.Style).IsEqualTo(Snippet.BlockOptions.StyleType.Allman);
    }
}