namespace MooVC.Syntax.CSharp.SnippetTests.BoundaryOptionsTests;

public sealed class WhenWithOpeningIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.BoundaryOptions();
        const string value = "[";

        // Act
        Snippet.BoundaryOptions result = options.WithOpening(value);

        // Assert
        result.ShouldNotBeSameAs(options);
        result.Opening.ShouldBe(value);
        options.Opening.ShouldNotBe(value);
    }
}
