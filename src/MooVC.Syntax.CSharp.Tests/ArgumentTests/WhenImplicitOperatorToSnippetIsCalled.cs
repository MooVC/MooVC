namespace MooVC.Syntax.CSharp.ArgumentTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Name = "value";
    private const string Content = "argument";

    [Test]
    public async Task GivenArgumentThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Argument
        {
            Name = new(Name),
            Value = Snippet.From(Content),
        };

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.From(subject.ToString()));
    }

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Argument? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }
}