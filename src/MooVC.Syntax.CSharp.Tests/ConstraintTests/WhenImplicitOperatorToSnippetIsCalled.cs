namespace MooVC.Syntax.CSharp.ConstraintTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Constraint? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenConstraintThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Constraint
        {
            Base = Base.Unspecified,
            Interfaces = [Implementation.Undefined],
            Nature = Nature.Unspecified,
        };

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.From(subject.ToString()));
    }
}