namespace MooVC.Syntax.CSharp.Members.SymbolTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Value = "Symbol";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Symbol? subject = default;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenSymbolThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Symbol
        {
            Name = Value,
        };

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}