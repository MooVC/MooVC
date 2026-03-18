namespace MooVC.Syntax.CSharp.Elements.ParameterTests.ModeTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Parameter.Mode? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenModeThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Parameter.Mode subject = Parameter.Mode.Scoped;

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.From(subject.ToString()));
    }
}