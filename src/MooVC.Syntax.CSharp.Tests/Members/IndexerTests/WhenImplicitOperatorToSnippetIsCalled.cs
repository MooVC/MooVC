namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using System;
using MooVC.Syntax.CSharp.Members;

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
    public void GivenIndexerThenSnippetMatchesToSnippet()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject));
    }
}
