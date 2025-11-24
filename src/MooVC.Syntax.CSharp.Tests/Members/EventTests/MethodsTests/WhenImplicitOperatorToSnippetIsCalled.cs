namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Event.Methods? subject = default;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.Empty);
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