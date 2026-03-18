namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.ModeTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Argument.Mode? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenModeThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Argument.Mode subject = Argument.Mode.In;

        // Act
        Snippet result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(Snippet.From(subject.ToString()));
    }
}