namespace MooVC.Syntax.CSharp.ArgumentTests.FormatterTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Format = "{0}={1}";

    [Test]
    public async Task GivenFormatterThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Argument.Formatter subject = Format;

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.From(Format));
    }

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Argument.Formatter? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }
}