namespace MooVC.Syntax.Formatting.StringExtensionsTests;

public sealed class WhenToSnippetIsCalled
{
    private const string FirstLine = "First";
    private const string SecondLine = "Second";
    private const string WhitespaceLine = " ";

    [Test]
    public async Task GivenSingleValueThenSingleLineSnippetIsReturned()
    {
        // Arrange
        const string value = FirstLine;

        // Act
        var result = value.ToSnippet();

        // Assert
        _ = await Assert.That(result.Lines).IsEqualTo(1);
        _ = await Assert.That(result.ToString()).IsEqualTo(value);
    }

    [Test]
    public async Task GivenEmptyStringThenSnippetIsNotEmpty()
    {
        // Arrange
        string value = string.Empty;

        // Act
        var result = value.ToSnippet();

        // Assert
        _ = await Assert.That(result.IsEmpty).IsFalse();
        _ = await Assert.That(result.Lines).IsEqualTo(1);
        _ = await Assert.That(result.ToString()).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValuesWithNullOrEmptyThenTheyAreFiltered()
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
        _ = await Assert.That(result.Lines).IsEqualTo(3);
        _ = await Assert.That(result.ToString()).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenOnlyNullOrEmptyValuesThenEmptySnippetIsReturned()
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
        _ = await Assert.That(result).IsEqualTo(Snippet.Empty);
    }
}