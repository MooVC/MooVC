namespace MooVC.Syntax.CSharp.ArgumentTests.OptionsTests.FormattersTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Format = "{0}={1}";

    [Test]
    public async Task GivenFormattersThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Argument.Options.Formatters subject = Format;

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.From(Format));
    }

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Argument.Options.Formatters? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }
}