namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Name = "TParameter";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Parameter? subject = default;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenParameterThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Parameter
        {
            Name = new Identifier(Name),
        };

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}
