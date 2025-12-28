namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Value = "BaseClass";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Base? @base = default;

        // Act
        Func<Snippet> result = () => @base;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenBaseThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Base subject = new Symbol
        {
            Name = Value,
        };

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}