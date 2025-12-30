namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Name = "TParameter";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Parameter? subject = default;

        // Act
        Func<WhenImplicitOperatorToSnippetIsCalled> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
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