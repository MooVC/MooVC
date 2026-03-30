namespace MooVC.Syntax.CSharp.IndexerTests.MethodsTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenMethodsThenStringMatchesToString()
    {
        // Arrange
        var subject = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

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
        Indexer.Methods? subject = default;

        // Act
        Func<string> result = () => subject!;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }
}