namespace MooVC.Syntax.Elements.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string First = "System";
    private const string Second = "Collections";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Qualifier? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenQualifierThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Qualifier subject = ImmutableArray.Create(
            new Name(First),
            new Name(Second));

        // Act
        Snippet result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(Snippet.From(subject.ToString()));
    }
}