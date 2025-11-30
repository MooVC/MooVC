namespace MooVC.Syntax.CSharp.Members.ParameterTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Default = "int";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Parameter? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenParameterThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Parameter subject = ParameterTestsData.Create(@default: Snippet.From(Default));

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}
