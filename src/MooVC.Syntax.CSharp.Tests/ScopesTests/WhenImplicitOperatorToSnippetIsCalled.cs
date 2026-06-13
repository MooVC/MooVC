namespace MooVC.Syntax.CSharp.ScopesTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Value = "public";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Scopes? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenScopeThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Scopes subject = Value;

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.From(subject.ToString()));
    }
}