namespace MooVC.Syntax.Elements.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenFromIsCalled
{
    [Test]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        string value = "alpha";
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = Snippet.From(options!, value));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Test]
    public void GivenNullValueThenThrows()
    {
        // Arrange
        string[]? values = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = Snippet.From(values!));

        // Assert
        exception.ParamName.ShouldBe(nameof(values));
    }

    [Test]
    public void GivenEmptyThenReturnsEmpty()
    {
        // Arrange & Act
        var result = Snippet.From(string.Empty);

        // Assert
        result.ShouldBe(Snippet.Empty);
        result.IsEmpty.ShouldBeTrue();
    }

    [Test]
    public void GivenTextThenCreatesSnippetFromLines()
    {
        // Arrange
        const string first = "alpha";
        const string second = "beta";
        string value = string.Join(Environment.NewLine, first, second);

        // Act
        var result = Snippet.From(value);
        ImmutableArray<string> converted = result;

        // Assert
        converted.ShouldBe([first, second]);
    }
}