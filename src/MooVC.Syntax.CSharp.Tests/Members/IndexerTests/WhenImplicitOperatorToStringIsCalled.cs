namespace MooVC.Syntax.CSharp.Members.IndexerTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Indexer? subject = default;

        // Act
        Func<string> result = () => subject!;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenIndexerThenStringMatchesToString()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        string expected = subject.ToString();

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(expected);
    }
}