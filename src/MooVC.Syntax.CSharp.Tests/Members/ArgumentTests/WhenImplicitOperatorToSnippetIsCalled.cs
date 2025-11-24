namespace MooVC.Syntax.CSharp.Members.ArgumentTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Name = "value";
    private const string Content = "argument";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Argument? subject = default;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenArgumentThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Argument
        {
            Name = new Identifier(Name),
            Value = Snippet.From(Content),
        };

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}
