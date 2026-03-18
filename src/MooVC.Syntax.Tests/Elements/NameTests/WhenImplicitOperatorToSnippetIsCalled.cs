namespace MooVC.Syntax.Elements.NameTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Value = "Segment";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Name? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenSegmentThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Name subject = Value;

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.From(subject.ToString()));
    }
}