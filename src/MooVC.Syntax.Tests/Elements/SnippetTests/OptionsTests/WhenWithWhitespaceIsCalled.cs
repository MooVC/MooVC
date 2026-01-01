namespace MooVC.Syntax.Elements.SnippetTests.OptionsTests;

public sealed class WhenWithWhitespaceIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.Options();
        Snippet value = "\t";

        // Act
        Snippet.Options result = options.WithWhitespace(value);

        // Assert
        result.ShouldNotBeSameAs(options);
        result.Whitespace.ShouldBe(value);
        options.Whitespace.ShouldNotBe(value);
    }
}