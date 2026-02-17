namespace MooVC.Syntax.Elements.NameTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Value = "Segment";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Name? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenSegmentThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Name subject = Value;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}