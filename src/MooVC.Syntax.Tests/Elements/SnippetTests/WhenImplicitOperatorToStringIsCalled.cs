namespace MooVC.Syntax.Elements.SnippetTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenNullSnippetThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Snippet? subject = default;

        // Act
        Func<string> action = () => subject;

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenSnippetThenReturnsStringRepresentation()
    {
        // Arrange
        var subject = "value";

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject);
    }
}