namespace MooVC.Syntax.Elements.SnippetTests.BoundaryOptionsTests;

public sealed class WhenWithClosingIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.BoundaryOptions();
        const string value = "]";

        // Act
        Snippet.BoundaryOptions result = options.WithClosing(value);

        // Assert
        result.ShouldNotBeSameAs(options);
        result.Closing.ShouldBe(value);
        options.Closing.ShouldNotBe(value);
    }
}