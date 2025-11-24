namespace MooVC.Syntax.CSharp.Members.SegmentTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Value = "Segment";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Segment? subject = default;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenSegmentThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Segment subject = Value;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}