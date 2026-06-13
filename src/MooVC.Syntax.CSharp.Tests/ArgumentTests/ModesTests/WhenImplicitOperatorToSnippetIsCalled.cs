namespace MooVC.Syntax.CSharp.ArgumentTests.ModesTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Test]
    public async Task GivenModeThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Argument.Modes subject = Argument.Modes.In;

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.From(subject.ToString()));
    }

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Argument.Modes? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }
}