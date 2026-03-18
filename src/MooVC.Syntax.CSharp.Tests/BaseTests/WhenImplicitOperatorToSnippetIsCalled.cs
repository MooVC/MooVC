namespace MooVC.Syntax.CSharp.BaseTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Value = "BaseClass";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Base? @base = default;

        // Act
        Func<Snippet> result = () => @base;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenBaseThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Base subject = new Symbol
        {
            Name = Value,
        };

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.From(subject.ToString()));
    }
}