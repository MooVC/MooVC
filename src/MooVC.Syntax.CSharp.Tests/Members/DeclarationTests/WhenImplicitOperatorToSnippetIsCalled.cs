namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Name = "Sample";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Declaration? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
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