namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Constructor? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenConstructorThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Constructor subject = ConstructorTestsData.Create();

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.From(subject.ToString()));
    }
}