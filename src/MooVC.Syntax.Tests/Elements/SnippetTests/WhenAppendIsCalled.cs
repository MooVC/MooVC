namespace MooVC.Syntax.Elements.SnippetTests;

public sealed class WhenAppendIsCalled
{
    private const string Alpha = "alpha";
    private const string Beta = "beta";
    private const string Gamma = "gamma";
    private const string Phi = "phi";

    [Test]
    public async Task GivenNullOptionsAndValuesThenThrows()
    {
        // Arrange
        var subject = Snippet.From(Alpha);
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = await Assert.That(
            () => _ = subject.Append(options!, Beta)).Throws<ArgumentNullException>();

        // Assert
        await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenStringValuesThenTheyAreAppended()
    {
        // Arrange
        string expected = string.Join(Environment.NewLine, Alpha, Beta, Gamma);
        var subject = Snippet.From(Alpha);

        // Act
        Snippet result = subject.Append(Beta, Gamma);

        // Assert
        string text = result.ToString();
        await Assert.That(text).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenMultiLineValuesThenTheLinesAreAppended()
    {
        // Arrange
        string expected = string.Join(Environment.NewLine, Alpha, Beta, Phi, Gamma);

        var subject = Snippet.From(Alpha);

        // Act
        Snippet result = subject.Append($"{Beta}{Environment.NewLine}{Phi}", Gamma);

        // Assert
        string text = result.ToString();
        await Assert.That(text).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenSnippetsThenTheyAreAppended()
    {
        // Arrange
        string expected = string.Join(Environment.NewLine, Alpha, Beta, Phi, Gamma);

        var subject = Snippet.From(Alpha);
        var first = Snippet.From($"{Beta}{Environment.NewLine}{Phi}");
        var second = Snippet.From(Gamma);

        // Act
        Snippet result = subject.Append(first, second);

        // Assert
        string text = result.ToString();
        await Assert.That(text).IsEqualTo(expected);
    }
}