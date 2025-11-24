namespace MooVC.Syntax.CSharp.Generics.Constraints.NatureTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Nature? subject = default;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNatureThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Nature subject = Nature.Class;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}