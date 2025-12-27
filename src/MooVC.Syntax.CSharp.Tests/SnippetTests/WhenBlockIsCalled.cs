namespace MooVC.Syntax.CSharp.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenBlockIsCalled
{
    private static readonly ImmutableArray<string> lines = ["if (condition)", "return true;"];

    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        var subject = new Snippet(lines);
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.Block(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

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
        Snippet result = subject.Block(Snippet.Options.Default);

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

        var subject = Snippet.From("return true;");
        var opening = Snippet.From("if (condition)");

        Snippet.Options options = new Snippet.Options()
            .WithBlock(block => block
                .WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces)
                .WithStyle(Snippet.BlockOptions.StyleType.Allman));

        // Act
        Snippet result = subject.Block(options, opening);

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

        var subject = Snippet.From("return true;");
        var opening = Snippet.From("if (condition)");

        Snippet.Options options = new Snippet.Options()
            .WithBlock(block => block
                .WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces)
                .WithStyle(Snippet.BlockOptions.StyleType.KAndR));

        // Act
        Snippet result = subject.Block(options, opening);

        // Assert
        string text = result.ToString();

        text.ShouldBe(expected);
    }
}