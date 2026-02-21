namespace MooVC.Syntax.Elements.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenBlockIsCalled
{
    private static readonly ImmutableArray<string> lines = ["if (condition)", "return true;"];

    [Fact]
    public void GivenNoOpeningThenTheWholeSnippetIsBlocked()
    {
        // Arrange
        const string expected = """
            {
                if (condition)
                return true;
            }
            """;

        var subject = new Snippet(lines);

        // Act
        Snippet result = subject.Block();

        // Assert
        string text = result.ToString();
        text.ShouldBe(expected);
    }

    [Fact]
    public void GivenAllmanStyleAndOpeningThenBlockIsExpanded()
    {
        // Arrange
        const string expected = """
            if (condition)
            {
                return true;
            }
            """;

        Snippet.Options options = new Snippet.Options()
            .WithBlock(block => block
                .WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces)
                .WithStyle(Snippet.BlockOptions.StyleType.Allman));
        var subject = Snippet.From(options, "return true;");
        var opening = Snippet.From("if (condition)");

        // Act
        Snippet result = subject.Block(opening);

        // Assert
        string text = result.ToString();

        text.ShouldBe(expected);
    }

    [Fact]
    public void GivenKAndRStyleAndOpeningThenBlockIsInline()
    {
        // Arrange
        const string expected = """
            if (condition) {
                return true;
            }
            """;

        Snippet.Options options = new Snippet.Options()
            .WithBlock(block => block
                .WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces)
                .WithStyle(Snippet.BlockOptions.StyleType.KAndR));
        var subject = Snippet.From(options, "return true;");
        var opening = Snippet.From("if (condition)");

        // Act
        Snippet result = subject.Block(opening);

        // Assert
        string text = result.ToString();

        text.ShouldBe(expected);
    }

    [Fact]
    public void GivenLambdaInlineThenSingleLineValueIsAppended()
    {
        // Arrange
        const string expected = "get => value;";

        Snippet.Options options = new Snippet.Options()
            .WithBlock(block => block
                .WithInline(Snippet.BlockOptions.InlineStyle.Lambda));
        var subject = Snippet.From(options, "value;");
        var opening = Snippet.From("get");

        // Act
        Snippet result = subject.Block(opening);

        // Assert
        string text = result.ToString();

        text.ShouldBe(expected);
    }

    [Fact]
    public void GivenSingleLineBracesThenSingleLineValueIsWrapped()
    {
        // Arrange
        const string expected = "get { value; }";

        Snippet.Options options = new Snippet.Options()
            .WithBlock(block => block
                .WithInline(Snippet.BlockOptions.InlineStyle.SingleLineBraces));
        var subject = Snippet.From(options, "value;");
        var opening = Snippet.From("get");

        // Act
        Snippet result = subject.Block(opening);

        // Assert
        string text = result.ToString();

        text.ShouldBe(expected);
    }
}