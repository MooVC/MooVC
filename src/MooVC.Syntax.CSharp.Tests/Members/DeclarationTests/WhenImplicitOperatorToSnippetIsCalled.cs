namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Name = "Sample";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Declaration? subject = default;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenDeclarationThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Declaration
        {
            Name = new Identifier(Name),
        };

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}