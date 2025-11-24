namespace MooVC.Syntax.CSharp.Members.ArgumentTests.FormatterTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Name = "value";
    private const string Format = "{0}={1}";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Argument.Formatter? subject = default;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenFormatterThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Argument.Formatter subject = Format;
        var name = new Identifier(Name);

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString(name, Snippet.Empty)));
    }
}
