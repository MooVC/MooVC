namespace MooVC.Syntax.Elements.SnippetTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenNullSnippetThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Snippet? subject = default;

        // Act
        Func<string> action = () => subject;

        // Assert
        await Assert.That(action).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenSnippetThenReturnsStringRepresentation()
    {
        // Arrange
        var subject = Snippet.From("value");

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(subject.ToString());
    }
}