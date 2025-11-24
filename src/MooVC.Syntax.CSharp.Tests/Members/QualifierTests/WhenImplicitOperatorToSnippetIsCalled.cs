namespace MooVC.Syntax.CSharp.Members.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string First = "System";
    private const string Second = "Collections";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Qualifier? subject = default;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenQualifierThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Qualifier subject = ImmutableArray.Create(
            new Segment(First),
            new Segment(Second));

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}