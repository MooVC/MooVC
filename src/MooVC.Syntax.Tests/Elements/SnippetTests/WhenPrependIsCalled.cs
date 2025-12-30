namespace MooVC.Syntax.Elements.SnippetTests;

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
        var subject = Snippet.From(Alpha);
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
        var subject = Snippet.From(Alpha);

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
        string expected = string.Join(Environment.NewLine, Beta, Phi, Gamma, Alpha);
        var subject = Snippet.From(Alpha);

        // Act
        Snippet result = subject.Prepend($"{Beta}{Environment.NewLine}{Phi}", Gamma);

        // Assert
        string text = result.ToString();
        text.ShouldBe(expected);
    }

    [Fact]
    public void GivenSnippetsThenTheyArePrepended()
    {
        // Arrange
        string expected = string.Join(Environment.NewLine, Beta, Phi, Gamma, Alpha);

        var subject = Snippet.From(Alpha);
        var first = Snippet.From($"{Beta}{Environment.NewLine}{Phi}");
        var second = Snippet.From(Gamma);

        // Act
        Snippet result = subject.Prepend(first, second);

        // Assert
        string text = result.ToString();
        text.ShouldBe(expected);
    }
}