namespace MooVC.Syntax.CSharp.SnippetTests.OptionsTests;

public sealed class WhenWithNewLineIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.Options();
        Snippet value = "\n";

        // Act
        Snippet.Options result = options.WithNewLine(value);

        // Assert
        result.ShouldNotBeSameAs(options);
        result.NewLine.ShouldBe(value);
        options.NewLine.ShouldNotBe(value);
    }
}