namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Fact]
    public void GivenNullMethodsThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Property.Methods? subject = default;

        // Act
        Func<Snippet> result = () => subject!;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenMethodsThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Property.Methods
        {
            Get = Snippet.From("value"),
        };

        string expected = subject.ToString();

        // Act
        Snippet result = subject;

        // Assert
        result.ToString().ShouldBe(expected);
    }
}