namespace MooVC.Syntax.CSharp.Members.IdentifierTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string IdentifierName = "Identifier";

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
        var subject = new Identifier(IdentifierName);

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}
