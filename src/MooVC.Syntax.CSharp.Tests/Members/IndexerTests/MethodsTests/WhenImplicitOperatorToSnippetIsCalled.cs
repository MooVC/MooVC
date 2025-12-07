namespace MooVC.Syntax.CSharp.Members.IndexerTests.MethodsTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Indexer.Methods? subject = default;

        // Act
        Func<Snippet> result = () => subject!;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenMethodsThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}
