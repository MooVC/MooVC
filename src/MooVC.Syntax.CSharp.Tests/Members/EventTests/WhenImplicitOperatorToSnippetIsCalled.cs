namespace MooVC.Syntax.CSharp.Members.EventTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Handler = "Handler";
    private const string Name = "Occurred";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Event? subject = default;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenEventThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Event
        {
            Handler = new Symbol(Handler),
            Name = new Identifier(Name),
        };

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}
