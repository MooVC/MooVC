namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Name = "IDisposable";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Interface? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenInterfaceThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Interface subject = new Declaration
        {
            Name = Name,
        };

        // Act
        Snippet result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(Snippet.From(subject.ToString()));
    }
}