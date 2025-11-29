namespace MooVC.Syntax.CSharp.Members.IdentifierTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string IdentifierName = "Identifier";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Identifier? identifier = default;

        // Act
        Func<Snippet> result = () => identifier;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenIdentifierThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Identifier(IdentifierName);

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}