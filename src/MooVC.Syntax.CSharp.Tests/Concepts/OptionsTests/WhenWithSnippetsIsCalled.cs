namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithSnippetsIsCalled
{
    [Fact]
    public void GivenSnippetsThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Options();
        Snippet.Options replacement = new Snippet.Options().WithWhitespace("	");

        // Act
        Options result = original.WithSnippets(replacement);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Snippets.ShouldBe(replacement);
        result.Namespace.ShouldBe(original.Namespace);
        result.IsDefault.ShouldBeFalse();
    }
}