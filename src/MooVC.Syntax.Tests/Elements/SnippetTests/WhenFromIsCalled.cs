namespace MooVC.Syntax.Elements.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenFromIsCalled
{
    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        string value = "alpha";
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = await Assert.That(() => _ = Snippet.From(options!, value)).Throws<ArgumentNullException>();

        // Assert
        await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenNullValueThenThrows()
    {
        // Arrange
        string[]? values = default;

        // Act
        ArgumentNullException exception = await Assert.That(() => _ = Snippet.From(values!)).Throws<ArgumentNullException>();

        // Assert
        await Assert.That(exception.ParamName).IsEqualTo(nameof(values));
    }

    [Test]
    public async Task GivenEmptyThenReturnsEmpty()
    {
        // Arrange & Act
        var result = Snippet.From(string.Empty);

        // Assert
        await Assert.That(result).IsEqualTo(Snippet.Empty);
        await Assert.That(result.IsEmpty).IsTrue();
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
        await Assert.That(converted).IsEqualTo([first, second]);
    }
}