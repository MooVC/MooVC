namespace MooVC.Syntax.SnippetTests;

public sealed class WhenPrependIsCalled
{
    private const string Alpha = "alpha";
    private const string Beta = "beta";
    private const string Gamma = "gamma";
    private const string Phi = "phi";

    [Test]
    public async Task GivenMultiLineValuesThenTheLinesArePrepended()
    {
        // Arrange
        string expected = string.Join(Environment.NewLine, Beta, Phi, Gamma, Alpha);
        var subject = Snippet.From(Alpha);

        // Act
        Snippet result = subject.Prepend($"{Beta}{Environment.NewLine}{Phi}", Gamma);

        // Assert
        string text = result.ToString();
        _ = await Assert.That(text).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenNullOptionsAndValuesThenThrows()
    {
        // Arrange
        var subject = Snippet.From(Alpha);
        Snippet.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = subject.Prepend(options!, Beta);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenSnippetsThenTheyArePrepended()
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
        _ = await Assert.That(text).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenStringValuesThenTheyArePrepended()
    {
        // Arrange
        string expected = string.Join(Environment.NewLine, Beta, Gamma, Alpha);
        var subject = Snippet.From(Alpha);

        // Act
        Snippet result = subject.Prepend(Beta, Gamma);

        // Assert
        string text = result.ToString();
        _ = await Assert.That(text).IsEqualTo(expected);
    }
}