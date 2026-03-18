namespace MooVC.Syntax.CSharp.DirectiveTests;

using System.Collections.Immutable;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Alias = "System";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Directive? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenDirectiveThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Directive
        {
            Alias = Alias,
            Qualifier = ImmutableArray.Create(new Name("Collections")),
        };

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.From(subject.ToString()));
    }
}