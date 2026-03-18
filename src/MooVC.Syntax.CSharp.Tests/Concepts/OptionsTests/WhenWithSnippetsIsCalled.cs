namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

public sealed class WhenWithSnippetsIsCalled
{
    [Test]
    public async Task GivenSnippetsThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Options();
        Snippet.Options replacement = new Snippet.Options().WithWhitespace("	");

        // Act
        Options result = original.WithSnippets(replacement);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Snippets).IsEqualTo(replacement);
        _ = await Assert.That(result.Namespace).IsEqualTo(original.Namespace);
        _ = await Assert.That(result.IsDefault).IsFalse();
    }
}