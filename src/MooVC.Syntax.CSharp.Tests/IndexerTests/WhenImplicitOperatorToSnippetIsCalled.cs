namespace MooVC.Syntax.CSharp.IndexerTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Indexer? subject = default;

        // Act
        Func<Snippet> result = () => subject!;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenIndexerThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        var expected = Snippet.From(subject.ToString());

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}