namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Event.Methods? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenMethodsThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Event.Methods
        {
            Add = Snippet.From("add => value"),
        };

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}