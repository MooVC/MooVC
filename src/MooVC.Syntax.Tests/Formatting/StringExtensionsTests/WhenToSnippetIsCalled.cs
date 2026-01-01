namespace MooVC.Syntax.Formatting.StringExtensionsTests;

using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    private const string FirstLine = "First";
    private const string SecondLine = "Second";
    private const string WhitespaceLine = " ";

    [Fact]
    public void GivenSingleValueThenSingleLineSnippetIsReturned()
    {
        // Arrange
        const string value = FirstLine;

        // Act
        var result = value.ToSnippet();

        // Assert
        result.Lines.ShouldBe(1);
        result.ToString().ShouldBe(value);
    }

    [Fact]
    public void GivenEmptyStringThenSnippetIsNotEmpty()
    {
        // Arrange
        string value = string.Empty;

        // Act
        var result = value.ToSnippet();

        // Assert
        result.IsEmpty.ShouldBeFalse();
        result.Lines.ShouldBe(1);
        result.ToString().ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesWithNullOrEmptyThenTheyAreFiltered()
    {
        // Arrange
        string?[] nullable =
        [
            FirstLine,
            string.Empty,
            default,
            WhitespaceLine,
            SecondLine,
        ];

        IEnumerable<string> values = nullable!;
        string expected = string.Join(Environment.NewLine, FirstLine, WhitespaceLine, SecondLine);

        // Act
        var result = values.ToSnippet();

        // Assert
        result.Lines.ShouldBe(3);
        result.ToString().ShouldBe(expected);
    }

    [Fact]
    public void GivenOnlyNullOrEmptyValuesThenEmptySnippetIsReturned()
    {
        // Arrange
        string?[] nullable =
        [
            string.Empty,
            default,
        ];

        IEnumerable<string> values = nullable!;

        // Act
        var result = values.ToSnippet();

        // Assert
        result.ShouldBe(Snippet.Empty);
    }
}