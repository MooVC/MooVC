namespace MooVC.Syntax.CSharp.SnippetTests;

public sealed class WhenAppendIsCalled
{
    private const string Alpha = "alpha";
    private const string Beta = "beta";
    private const string Gamma = "gamma";
    private const string Phi = "phi";

    [Fact]
    public void GivenNullOptionsAndValuesThenThrows()
    {
        // Arrange
        var subject = Snippet.From(Alpha);
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(
            () => _ = subject.Append(options!, Beta));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenStringValuesThenTheyAreAppended()
    {
        // Arrange
        string expected = string.Join(Environment.NewLine, Alpha, Beta, Gamma);
        var subject = Snippet.From(Alpha);

        // Act
        Snippet result = subject.Append(Beta, Gamma);

        // Assert
        string text = result.ToString();
        text.ShouldBe(expected);
    }

    [Fact]
    public void GivenMultiLineValuesThenTheLinesAreAppended()
    {
        // Arrange
        Snippet.Options options = new Snippet.Options()
            .WithNewLine("\n");

        string expected = string.Join(options.NewLine, Alpha, Beta, Phi, Gamma);

        var subject = Snippet.From(options, Alpha);

        // Act
        Snippet result = subject.Append(options, $"{Beta}\n{Phi}", Gamma);

        // Assert
        string text = result.ToString(options);
        text.ShouldBe(expected);
    }

    [Fact]
    public void GivenSnippetsThenTheyAreAppended()
    {
        // Arrange
        Snippet.Options options = new Snippet.Options()
            .WithNewLine("\n");

        string expected = string.Join(options.NewLine, Alpha, Beta, Phi, Gamma);

        var subject = Snippet.From(options, Alpha);
        var first = Snippet.From(options, $"{Beta}\n{Phi}");
        var second = Snippet.From(options, Gamma);

        // Act
        Snippet result = subject.Append(first, second);

        // Assert
        string text = result.ToString(options);
        text.ShouldBe(expected);
    }
}