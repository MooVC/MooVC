namespace MooVC.Syntax.CSharp.IndexerTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenIndexerThenStringMatchesToString()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        string expected = subject.ToString();

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Indexer? subject = default;

        // Act
        Func<string> result = () => subject!;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }
}