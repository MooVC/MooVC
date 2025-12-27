namespace MooVC.Syntax.CSharp.Members.ParameterTests.ModeTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Parameter.Mode? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenModeThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Parameter.Mode subject = Parameter.Mode.Scoped;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}