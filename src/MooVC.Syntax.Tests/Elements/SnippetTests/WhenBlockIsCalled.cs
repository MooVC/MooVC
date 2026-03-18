namespace MooVC.Syntax.Elements.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenBlockIsCalled
{
    private static readonly ImmutableArray<string> _lines = ["if (condition)", "return true;"];

    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        var subject = new Snippet(_lines);
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = await Assert.That(() => _ = subject.Block(options!)).Throws<ArgumentNullException>();

        // Assert
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenNoOpeningThenTheWholeSnippetIsBlocked()
    {
        // Arrange
        const string expected = """
            {
                if (condition)
                return true;
            }
            """;

        var subject = new Snippet(_lines);

        // Act
        Snippet result = subject.Block(Snippet.Options.Default);

        // Assert
        string text = result.ToString();
        _ = await Assert.That(text).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenAllmanStyleAndOpeningThenBlockIsExpanded()
    {
        // Arrange
        const string expected = """
            if (condition)
            {
                return true;
            }
            """;

        var subject = Snippet.From("return true;");
        var opening = Snippet.From("if (condition)");

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block
                .WithStyle(Snippet.BlockOptions.StyleType.Allman));

        // Act
        Snippet result = subject.Block(options, opening);

        // Assert
        string text = result.ToString();

        _ = await Assert.That(text).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenKAndRStyleAndOpeningThenBlockIsInline()
    {
        // Arrange
        const string expected = """
            if (condition) {
                return true;
            }
            """;

        var subject = Snippet.From("return true;");
        var opening = Snippet.From("if (condition)");

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block
                .WithStyle(Snippet.BlockOptions.StyleType.KAndR));

        // Act
        Snippet result = subject.Block(options, opening);

        // Assert
        string text = result.ToString();

        _ = await Assert.That(text).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenLambdaInlineThenSingleLineValueIsAppended()
    {
        // Arrange
        const string expected = "get => value;";

        var subject = Snippet.From("value;");
        var opening = Snippet.From("get");

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block
                .WithInline(inline => inline
                    .WithCode(Snippet.BlockOptions.InlineStyle.Lambda)));

        // Act
        Snippet result = subject.Block(options, opening);

        // Assert
        string text = result.ToString();

        _ = await Assert.That(text).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenSingleLineBracesThenSingleLineValueIsWrapped()
    {
        // Arrange
        const string expected = "get { value; }";

        var subject = Snippet.From("value;");
        var opening = Snippet.From("get");

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block
                .WithInline(inline => inline
                    .WithCode(Snippet.BlockOptions.InlineStyle.SingleLineBraces)));

        // Act
        Snippet result = subject.Block(options, opening);

        // Assert
        string text = result.ToString();

        _ = await Assert.That(text).IsEqualTo(expected);
    }
}