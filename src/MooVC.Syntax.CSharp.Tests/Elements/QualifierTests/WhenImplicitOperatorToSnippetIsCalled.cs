namespace MooVC.Syntax.CSharp.Elements.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string First = "System";
    private const string Second = "Collections";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Qualifier? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
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