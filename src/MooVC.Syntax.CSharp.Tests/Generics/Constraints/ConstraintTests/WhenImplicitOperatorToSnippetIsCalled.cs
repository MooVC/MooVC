namespace MooVC.Syntax.CSharp.Generics.Constraints.ConstraintTests;

using Shouldly;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Constraint? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenConstraintThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Constraint
        {
            Base = Base.Unspecified,
            Interfaces = [Interface.Undefined],
            Nature = Nature.Unspecified,
        };

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}