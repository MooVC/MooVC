namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Snippets).IsEqualTo(replacement);
        await Assert.That(result.Namespace).IsEqualTo(original.Namespace);
        await Assert.That(result.IsDefault).IsFalse();
    }
}