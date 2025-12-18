namespace MooVC.Syntax.CSharp.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenShiftIsCalled
{
    private static readonly ImmutableArray<string> lines = ["if (condition)", "return true;"];

    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        var subject = new Snippet(lines);
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.Shift(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenOptionsThenLinesAreShifted()
    {
        // Arrange
        const string expected = """
            	if (condition)
            	return true;
            """;

        const string whitespace = "\t";
        var subject = new Snippet(lines);

        Snippet.Options options = new Snippet.Options()
            .WithNewLine(Environment.NewLine)
            .WithWhitespace(whitespace);

        // Act
        Snippet result = subject.Shift(options);

        // Assert
        string text = result.ToString();
        text.ShouldBe(expected);
    }
}