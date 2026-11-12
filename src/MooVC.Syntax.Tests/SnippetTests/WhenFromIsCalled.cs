namespace MooVC.Syntax.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenFromIsCalled
{
    private const string CarriageReturn = "\r";
    private const string CarriageReturnLineFeed = "\r\n";
    private const string First = "alpha";
    private const string LineFeed = "\n";
    private const string Second = "beta";
    private const string Third = "gamma";

    [Test]
    public async Task GivenEmptyThenReturnsEmpty()
    {
        // Arrange & Act
        var result = Snippet.From(string.Empty);

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(result.IsEmpty).IsTrue();
    }

    [Test]
    public async Task GivenMixedLineEndingsThenConsecutiveAndTrailingEmptyLinesArePreserved()
    {
        // Arrange
        const string value = First + CarriageReturnLineFeed + CarriageReturn + Second + LineFeed + Third + CarriageReturnLineFeed + CarriageReturn;
        string[] lines = [First, string.Empty, Second, Third, string.Empty, string.Empty];
        string expected = string.Join(Environment.NewLine, lines);

        // Act
        var result = Snippet.From(Snippet.Options.Default, value);

        // Assert
        _ = await Assert.That(result.Lines).IsEqualTo(lines.Length);
        _ = await Assert.That(result.ToString()).IsEqualTo(expected);
    }

    [Test]
    [Arguments(CarriageReturn)]
    [Arguments(CarriageReturnLineFeed)]
    [Arguments(LineFeed)]
    public async Task GivenOnlyNewLineThenReturnsBlank(string lineEnding)
    {
        // Arrange & Act
        var result = Snippet.From(lineEnding);

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.Blank);
    }

    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        string value = "alpha";
        Snippet.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = Snippet.From(options!, value);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenNullValueThenThrows()
    {
        // Arrange
        string[]? values = default;

        // Act
        Func<Snippet> act = () => _ = Snippet.From(values!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(values));
    }

    [Test]
    [Arguments(CarriageReturn)]
    [Arguments(CarriageReturnLineFeed)]
    [Arguments(LineFeed)]
    public async Task GivenTextThenCreatesSnippetFromLines(string lineEnding)
    {
        // Arrange
        string value = string.Join(lineEnding, First, Second);

        // Act
        var result = Snippet.From(value);
        ImmutableArray<string> converted = result;

        // Assert
        _ = await Assert.That(converted).IsEquivalentTo([First, Second]);
    }
}