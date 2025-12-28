namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Alias = "System";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Directive? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenDirectiveThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Directive
        {
            Alias = Alias,
            Qualifier = ImmutableArray.Create(new Segment("Collections")),
        };

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}