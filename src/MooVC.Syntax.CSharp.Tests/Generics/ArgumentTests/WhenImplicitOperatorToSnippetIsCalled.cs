namespace MooVC.Syntax.CSharp.Generics.ArgumentTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Name = "TArgument";

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

    [Test]
    public async Task GivenArgumentThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Argument
        {
            Name = Name,
        };

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.From(subject.ToString()));
    }
}