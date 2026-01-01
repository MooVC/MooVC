namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Indexer? subject = default;

        // Act
        Func<Snippet> result = () => subject!;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenIndexerThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        var expected = Snippet.From(subject.ToString());

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(expected);
    }
}