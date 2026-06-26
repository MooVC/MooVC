namespace MooVC.Syntax.SnippetTests.OptionsTests.BlocksTests;

public sealed class WhenWithMarkersIsCalled
{
    [Test]
    public async Task GivenMarkersThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.Options.Blocks();

        Snippet.Options.Blocks.Boundaries markers = options.Markers
            .WithOpening("[")
            .WithClosing("]");

        // Act
        Snippet.Options.Blocks result = options.WithMarkers(markers);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(options);
        _ = await Assert.That(result.Markers).IsEqualTo(markers);
        _ = await Assert.That(options.Markers).IsNotEqualTo(markers);
    }
}