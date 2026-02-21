namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.FormatterTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Format = "{0}={1}";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Argument.Formatter? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenFormatterThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Argument.Formatter subject = Format;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Format);
    }
}