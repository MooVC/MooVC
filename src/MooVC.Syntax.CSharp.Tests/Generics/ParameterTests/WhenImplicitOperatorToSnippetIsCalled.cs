namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Name = "TParameter";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Parameter? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenParameterThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Parameter
        {
            Name = Name,
        };

        // Act
        Snippet result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(Snippet.From(subject.ToString()));
    }
}