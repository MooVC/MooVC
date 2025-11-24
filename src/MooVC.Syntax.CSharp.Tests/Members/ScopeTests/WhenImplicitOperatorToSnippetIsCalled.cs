namespace MooVC.Syntax.CSharp.Members.ScopeTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Value = "public";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Scope? subject = default;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.Empty);
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