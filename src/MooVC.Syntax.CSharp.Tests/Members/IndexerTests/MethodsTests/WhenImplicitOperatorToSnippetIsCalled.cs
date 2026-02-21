namespace MooVC.Syntax.CSharp.Members.IndexerTests.MethodsTests;

using MooVC.Syntax.Elements;

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

        var expected = Snippet.From(subject.ToString());

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(expected);
    }
}