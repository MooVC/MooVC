namespace MooVC.Syntax.CSharp.StringExtensionsTests;

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
        Snippet result = value.ToSnippet();

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
        Snippet result = value.ToSnippet();

        // Assert
        result.IsEmpty.ShouldBeFalse();
        result.Lines.ShouldBe(1);
        result.ToString().ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesWithNullOrEmptyThenTheyAreFiltered()
    {
        // Arrange
        IEnumerable<string> values = new string?[]
        {
            FirstLine,
            string.Empty,
            null,
            WhitespaceLine,
            SecondLine,
        }!;

        string expected = string.Join(Environment.NewLine, FirstLine, WhitespaceLine, SecondLine);

        // Act
        Snippet result = values.ToSnippet();

        // Assert
        result.Lines.ShouldBe(3);
        result.ToString().ShouldBe(expected);
    }

    [Fact]
    public void GivenOnlyNullOrEmptyValuesThenEmptySnippetIsReturned()
    {
        // Arrange
        IEnumerable<string> values = new string?[]
        {
            string.Empty,
            null,
        }!;

        // Act
        Snippet result = values.ToSnippet();

        // Assert
        result.ShouldBe(Snippet.Empty);
    }
}
