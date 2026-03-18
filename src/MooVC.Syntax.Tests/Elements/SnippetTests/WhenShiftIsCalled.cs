namespace MooVC.Syntax.Elements.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenShiftIsCalled
{
    private static readonly ImmutableArray<string> lines = ["if (condition)", "return true;"];

    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        var subject = new Snippet(lines);
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = await Assert.That(() => _ = subject.Shift(options!)).Throws<ArgumentNullException>();

        // Assert
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenOptionsThenLinesAreShifted()
    {
        // Arrange
        const string expected = """
            	if (condition)
            	return true;
            """;

        const string whitespace = "\t";
        var subject = new Snippet(lines);

        Snippet.Options options = new Snippet.Options()
            .WithWhitespace(whitespace);

        // Act
        Snippet result = subject.Shift(options);

        // Assert
        string text = result.ToString();
        _ = await Assert.That(text).IsEqualTo(expected);
    }
}