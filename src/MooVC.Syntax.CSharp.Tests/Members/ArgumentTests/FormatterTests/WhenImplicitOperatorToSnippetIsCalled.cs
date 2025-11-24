namespace MooVC.Syntax.CSharp.Members.ArgumentTests.FormatterTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Format = "{0}={1}";

    [Fact]
    public void GivenNullSubjectThenCallIsReturned()
    {
        // Arrange
        Argument.Formatter? subject = default;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(Argument.Formatter.Call));
    }

    [Fact]
    public void GivenFormatterThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Argument.Formatter subject = Format;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(Format));
    }
}