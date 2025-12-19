namespace MooVC.Syntax.CSharp.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenFromIsCalled
{
    [Fact]
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

    [Fact]
    public void GivenNullValueThenThrows()
    {
        // Arrange
        string[]? values = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = Snippet.From(values!));

        // Assert
        exception.ParamName.ShouldBe(nameof(values));
    }

    [Fact]
    public void GivenEmptyThenReturnsEmpty()
    {
        // Arrange & Act
        var result = Snippet.From(string.Empty);

        // Assert
        result.ShouldBe(Snippet.Empty);
        result.IsEmpty.ShouldBeTrue();
    }

    [Fact]
    public void GivenTextThenCreatesSnippetFromLines()
    {
        // Arrange
        const string first = "alpha";
        const string second = "beta";
        const string newLine = "\n";
        string value = string.Join(newLine, first, second);

        Snippet.Options options = new Snippet.Options()
            .WithNewLine(newLine);

        // Act
        var result = Snippet.From(options, value);
        ImmutableArray<string> converted = result;

        // Assert
        converted.ShouldBe([first, second]);
    }
}