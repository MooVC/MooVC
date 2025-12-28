namespace MooVC.Syntax.CSharp.Members.EventTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Handler = "Handler";
    private const string Name = "Occurred";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Event? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenEventThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Event
        {
            Handler = new Symbol { Name = Handler },
            Name = Name,
        };

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}