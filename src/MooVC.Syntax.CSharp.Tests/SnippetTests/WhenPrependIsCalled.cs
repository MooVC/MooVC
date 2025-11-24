namespace MooVC.Syntax.CSharp.SnippetTests;

public sealed class WhenPrependIsCalled
{
    private const string Alpha = "alpha";
    private const string Beta = "beta";
    private const string Gamma = "gamma";
    private const string Phi = "phi";

    [Fact]
    public void GivenNullOptionsAndValuesThenThrows()
    {
        // Arrange
        Snippet subject = Snippet.From(Alpha);
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(
            () => _ = subject.Prepend(options!, Beta));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenStringValuesThenTheyArePrepended()
    {
        // Arrange
        string expected = string.Join(Environment.NewLine, Beta, Gamma, Alpha);

        Snippet subject = Snippet.From(Alpha);

        // Act
        Snippet result = subject.Prepend(Beta, Gamma);

        // Assert
        string text = result.ToString();
        text.ShouldBe(expected);
    }

    [Fact]
    public void GivenMultiLineValuesThenTheLinesArePrepended()
    {
        // Arrange
        Snippet.Options options = new Snippet.Options()
            .WithNewLine("\n");

        string expected = string.Join(options.NewLine, Beta, Phi, Gamma, Alpha);

        Snippet subject = Snippet.From(Alpha, options);

        // Act
        Snippet result = subject.Prepend(options, $"{Beta}\n{Phi}", Gamma);

        // Assert
        string text = result.ToString(options);
        text.ShouldBe(expected);
    }

    [Fact]
    public void GivenSnippetsThenTheyArePrepended()
    {
        // Arrange
        Snippet.Options options = new Snippet.Options()
            .WithNewLine("\n");

        string expected = string.Join(options.NewLine, Beta, Phi, Gamma, Alpha);

        Snippet subject = Snippet.From(Alpha, options);
        Snippet first = Snippet.From($"{Beta}\n{Phi}", options);
        Snippet second = Snippet.From(Gamma, options);

        // Act
        Snippet result = subject.Prepend(first, second);

        // Assert
        string text = result.ToString(options);
        text.ShouldBe(expected);
    }
}
