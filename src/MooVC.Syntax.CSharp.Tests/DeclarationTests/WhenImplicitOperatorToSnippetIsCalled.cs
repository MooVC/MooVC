namespace MooVC.Syntax.CSharp.DeclarationTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Name = "Sample";

    [Test]
    public async Task GivenDeclarationThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Declaration
        {
            Name = Name,
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
        Declaration? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }
}