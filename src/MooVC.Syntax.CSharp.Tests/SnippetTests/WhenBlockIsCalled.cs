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
    public void GivenAllmanStyleThenBlockIsExpanded()
    {
        // Arrange
        const string expected = """
            if (condition)
            {
                return true;
            }
            """;

        var subject = new Snippet(lines);

        Snippet.Options options = new Snippet.Options()
            .WithNewLine(Environment.NewLine);

        // Act
        Snippet result = subject.Block(options);

        // Assert
        string text = result.ToString(options);
        text.ShouldBe(expected);
    }

    [Fact]
    public void GivenKAndRStyleThenBlockIsInline()
    {
        // Arrange
        const string expected = """
            if (condition) {
                return true;
            }
            """;

        var subject = new Snippet(lines);

        Snippet.Options options = new Snippet.Options()
            .WithNewLine(Environment.NewLine)
            .WithBlock(block => block.WithStyle(Snippet.BlockOptions.StyleType.KAndR));

        // Act
        Snippet result = subject.Block(options);

        // Assert
        string text = result.ToString(options);

        text.ShouldBe(expected);
    }
}