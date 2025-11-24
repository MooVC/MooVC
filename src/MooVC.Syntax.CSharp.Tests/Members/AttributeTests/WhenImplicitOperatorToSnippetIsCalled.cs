namespace MooVC.Syntax.CSharp.Members.AttributeTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string Name = "Obsolete";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Attribute? subject = default;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenAttributeThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Attribute
        {
            Name = new Symbol
            {
                Name = Name,
            },
        };

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}