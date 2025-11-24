namespace MooVC.Syntax.CSharp.Members.QualifierTests;

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
        var subject = new Qualifier
        {
            new Segment(First),
            new Segment(Second),
        };

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}
