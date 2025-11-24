namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Name = "IDisposable";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Interface? subject = default;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenInterfaceThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Interface
        {
            Declaration = new Declaration
            {
                Name = new Identifier(Name),
            },
        };

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}
