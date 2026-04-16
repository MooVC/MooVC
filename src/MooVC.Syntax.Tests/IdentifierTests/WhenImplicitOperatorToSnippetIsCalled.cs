namespace MooVC.Syntax.IdentifierTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string IdentifierName = "Identifier";

    [Test]
    public async Task GivenIdentifierThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Identifier(IdentifierName);

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.From(subject.ToString()));
    }

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Identifier? identifier = default;

        // Act
        Func<Snippet> result = () => identifier;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }
}