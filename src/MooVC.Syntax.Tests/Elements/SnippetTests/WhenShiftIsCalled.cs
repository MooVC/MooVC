namespace MooVC.Syntax.Elements.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenShiftIsCalled
{
    private static readonly ImmutableArray<string> lines = ["if (condition)", "return true;"];

    [Fact]
    public void GivenOptionsFromConstructionThenLinesAreShifted()
    {
        // Arrange
        const string expected = """
            	if (condition)
            	return true;
            """;

        const string whitespace = "	";

        Snippet.Options options = new Snippet.Options()
            .WithWhitespace(whitespace);
        var subject = new Snippet(options, lines);

        // Act
        Snippet result = subject.Shift();

        // Assert
        string text = result.ToString();
        text.ShouldBe(expected);
    }
}