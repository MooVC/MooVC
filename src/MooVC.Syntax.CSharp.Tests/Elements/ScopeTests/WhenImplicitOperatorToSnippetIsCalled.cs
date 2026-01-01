namespace MooVC.Syntax.CSharp.Elements.ScopeTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Value = "public";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Scope? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenScopeThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Scope subject = Value;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}