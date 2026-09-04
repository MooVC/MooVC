namespace MooVC.Syntax.CSharp.TypeTests.OptionsTests;

public sealed class WhenWithSnippetsIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Type.Options();
        Snippet.Options value = Snippet.Options.Default.WithWhitespace("  ");

        // Act
        Type.Options result = options.WithSnippets(value);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(options);
        _ = await Assert.That(result.Snippets).IsEqualTo(value);
        _ = await Assert.That(options.Snippets).IsNotEqualTo(value);
    }
}