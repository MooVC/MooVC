namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string NamedIdentifier = "TNamed";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Identifier? subject = default;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenIdentifierThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Identifier(NamedIdentifier);

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}