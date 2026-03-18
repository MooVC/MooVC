namespace MooVC.Syntax.Elements.SnippetTests.BlockOptionsTests;

public sealed class WhenWithMarkersIsCalled
{
    [Test]
    public async Task GivenMarkersThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.BlockOptions();

        Snippet.BoundaryOptions markers = options.Markers
            .WithOpening("[")
            .WithClosing("]");

        // Act
        Snippet.BlockOptions result = options.WithMarkers(markers);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(options);
        _ = await Assert.That(result.Markers).IsEqualTo(markers);
        _ = await Assert.That(options.Markers).IsNotEqualTo(markers);
    }
}