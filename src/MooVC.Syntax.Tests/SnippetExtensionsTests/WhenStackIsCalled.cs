namespace MooVC.Syntax.SnippetExtensionsTests;

using System.Collections.Immutable;

public sealed class WhenStackIsCalled
{
    private const string FirstLine = "First";
    private const string SecondLine = "Second";
    private const string ThirdLine = "Third";

    [Test]
    public async Task GivenSingleSnippetThenOriginalSnippetIsReturned()
    {
        // Arrange
        var snippet = Snippet.From(FirstLine);
        var snippets = ImmutableArray.Create(snippet);

        // Act
        Snippet result = snippets.Stack(Snippet.Options.Default);

        // Assert
        _ = await Assert.That(result).IsStrictlyEqualTo(snippet);
    }

    [Test]
    public async Task GivenMultipleSnippetsThenTheyAreStackedInOrder()
    {
        // Arrange
        var first = Snippet.From(FirstLine);
        var second = Snippet.From(SecondLine);
        var third = Snippet.From(ThirdLine);
        var snippets = ImmutableArray.Create(first, second, third);
        string expected = string.Join(Environment.NewLine, FirstLine, SecondLine, ThirdLine);

        // Act
        Snippet result = snippets.Stack(Snippet.Options.Default);

        // Assert
        _ = await Assert.That(result.ToString()).IsEquivalentTo(expected);
    }
}