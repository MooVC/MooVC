namespace MooVC.Syntax.CSharp.Members.ArgumentTests.ModeTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Argument.Mode? subject = default;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.Empty);
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
