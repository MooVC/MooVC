namespace MooVC.Syntax.Elements.SnippetExtensionsTests;

using System.Collections.Immutable;

public sealed class WhenStackIsCalled
{
    private const string FirstLine = "First";
    private const string SecondLine = "Second";
    private const string ThirdLine = "Third";

    [Fact]
    public void GivenSingleSnippetThenOriginalSnippetIsReturned()
    {
        // Arrange
        var snippet = FirstLine;
        var snippets = ImmutableArray.Create(snippet);

        // Act
        Snippet result = snippets.Stack(Snippet.Options.Default);

        // Assert
        result.ShouldBeSameAs(snippet);
    }

    [Fact]
    public void GivenMultipleSnippetsThenTheyAreStackedInOrder()
    {
        // Arrange
        var first = FirstLine;
        var second = SecondLine;
        var third = ThirdLine;
        var snippets = ImmutableArray.Create(first, second, third);
        string expected = string.Join(Environment.NewLine, FirstLine, SecondLine, ThirdLine);

        // Act
        Snippet result = snippets.Stack(Snippet.Options.Default);

        // Assert
        result.ToString().ShouldBe(expected);
    }
}