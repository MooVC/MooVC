namespace MooVC.Syntax.CSharp.EventTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Handler = "Handler";
    private const string Name = "Occurred";

    [Test]
    public async Task GivenEventThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Event
        {
            Handler = new() { Name = Handler },
            Name = Name,
        };

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.From(subject.ToString()));
    }

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Event? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }
}