namespace MooVC.Syntax.CSharp.Members.IndexerTests.MethodsTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Indexer.Methods? subject = default;

        // Act
        Func<string> result = () => subject!;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenMethodsThenStringMatchesToString()
    {
        // Arrange
        var subject = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}
