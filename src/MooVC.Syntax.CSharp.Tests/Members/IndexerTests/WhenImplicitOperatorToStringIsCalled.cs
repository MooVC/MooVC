namespace MooVC.Syntax.CSharp.Members.IndexerTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Indexer? subject = default;

        // Act
        Func<string> result = () => subject!;

        // Assert
        await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenIndexerThenStringMatchesToString()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        string expected = subject.ToString();

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }
}