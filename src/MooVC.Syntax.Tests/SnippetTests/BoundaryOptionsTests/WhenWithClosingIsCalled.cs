namespace MooVC.Syntax.SnippetTests.BoundaryOptionsTests;

public sealed class WhenWithClosingIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.BoundaryOptions();
        const string value = "]";

        // Act
        Snippet.BoundaryOptions result = options.WithClosing(value);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(options);
        _ = await Assert.That(result.Closing).IsEqualTo(value);
        _ = await Assert.That(options.Closing).IsNotEqualTo(value);
    }
}