namespace MooVC.Syntax.CSharp.AttributeTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Name = "Obsolete";

    [Test]
    public async Task GivenAttributeThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Attribute
        {
            Name = new()
            {
                Name = Name,
            },
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
        Attribute? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }
}