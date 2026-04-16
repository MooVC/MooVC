namespace MooVC.Syntax.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenShiftIsCalled
{
    private static readonly ImmutableArray<string> _lines = ["if (condition)", "return true;"];

    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        var subject = new Snippet(_lines);
        Snippet.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = subject.Shift(options!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
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
        var subject = new Snippet(_lines);

        var options = new Snippet.Options()
            .WithWhitespace(whitespace);

        // Act
        Snippet result = subject.Shift(options);

        // Assert
        string text = result.ToString();
        _ = await Assert.That(text).IsEqualTo(expected);
    }
}