namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Value = "BaseClass";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Base? subject = default;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenBaseThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Base
        {
            Type = new Declaration
            {
                Name = new Identifier(Value),
            },
        };

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}
