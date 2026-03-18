namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.Elements;

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
        await Assert.That(result).Throws<ArgumentNullException>();
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
        await Assert.That(result).IsEqualTo(expected);
    }
}