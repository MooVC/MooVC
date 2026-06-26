namespace MooVC.Syntax.SnippetTests.OptionsTests.BlocksTests.BoundariesTests;

public sealed class WhenWithOpeningIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.Options.Blocks.Boundaries();
        const string value = "[";

        // Act
        Snippet.Options.Blocks.Boundaries result = options.WithOpening(value);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(options);
        _ = await Assert.That(result.Opening).IsEqualTo(value);
        _ = await Assert.That(options.Opening).IsNotEqualTo(value);
    }
}