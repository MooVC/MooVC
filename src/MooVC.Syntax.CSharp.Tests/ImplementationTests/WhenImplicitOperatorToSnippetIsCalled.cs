namespace MooVC.Syntax.CSharp.ImplementationTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Name = "IDisposable";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Implementation? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenImplementationThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Implementation subject = new Declaration
        {
            Name = Name,
        };

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.From(subject.ToString()));
    }
}