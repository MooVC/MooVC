namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.ModeTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Argument.Mode? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenModeThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Argument.Mode subject = Argument.Mode.In;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}