namespace MooVC.Syntax.SnippetTests.OptionsTests.BlocksTests.BoundariesTests;

public sealed class WhenWithClosingIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.Options.Blocks.Boundaries();
        const string value = "]";

        // Act
        Snippet.Options.Blocks.Boundaries result = options.WithClosing(value);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(options);
        _ = await Assert.That(result.Closing).IsEqualTo(value);
        _ = await Assert.That(options.Closing).IsNotEqualTo(value);
    }
}