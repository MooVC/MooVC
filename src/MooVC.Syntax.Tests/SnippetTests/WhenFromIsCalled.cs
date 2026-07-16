namespace MooVC.Syntax.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenFromIsCalled
{
    [Test]
    public async Task GivenEmptyThenReturnsEmpty()
    {
        // Arrange & Act
        var result = Snippet.From(string.Empty);

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(result.IsEmpty).IsTrue();
    }

    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        string value = "alpha";
        Snippet.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = Snippet.From(options!, value);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenNullValueThenThrows()
    {
        // Arrange
        string[]? values = default;

        // Act
        Func<Snippet> act = () => _ = Snippet.From(values!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(values));
    }

    [Test]
    public async Task GivenTextThenCreatesSnippetFromLines()
    {
        // Arrange
        const string first = "alpha";
        const string second = "beta";
        string value = string.Join(Environment.NewLine, first, second);

        // Act
        var result = Snippet.From(value);
        ImmutableArray<string> converted = result;

        // Assert
        _ = await Assert.That(converted).IsEquivalentTo([first, second]);
    }
}