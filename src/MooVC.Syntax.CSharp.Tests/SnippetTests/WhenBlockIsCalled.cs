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
        var subject = new Snippet(lines);
        var options = new Snippet.Options()
            .WithNewLine("\n");

        // Act
        Snippet result = subject.Block(options);

        // Assert
        string text = result.ToString(options);
        text.ShouldBe(
            """
            if (condition)
            {
                return true;
            }
            """
                .Trim());
    }

    [Fact]
    public void GivenKAndRStyleThenBlockIsInline()
    {
        // Arrange
        var subject = new Snippet(lines);
        Snippet.Options options = new Snippet.Options()
            .WithNewLine("\n");

        Snippet.BlockOptions blockOptions = options.Block
            .WithStyle(Snippet.BlockOptions.StyleType.KAndR);

        options = options.WithBlock(blockOptions);

        // Act
        Snippet result = subject.Block(options);

        // Assert
        string text = result.ToString(options);
        text.ShouldBe(
            """
            if (condition) {
                return true;
            }
            """
                .Trim());
    }
}
