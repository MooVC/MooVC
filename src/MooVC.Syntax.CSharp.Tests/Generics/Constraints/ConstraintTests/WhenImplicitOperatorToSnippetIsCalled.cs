namespace MooVC.Syntax.CSharp.Generics.Constraints.ConstraintTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Constraint? subject = default;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenConstraintThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Constraint
        {
            Base = Base.Unspecified,
            Interface = Interface.Unspecified,
            Nature = Nature.Unspecified,
        };

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}
