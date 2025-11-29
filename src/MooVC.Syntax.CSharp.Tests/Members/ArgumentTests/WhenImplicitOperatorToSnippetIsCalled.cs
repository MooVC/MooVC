namespace MooVC.Syntax.CSharp.Members.ArgumentTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Name = "value";
    private const string Content = "argument";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Argument? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
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