namespace MooVC.Syntax.CSharp.SnippetTests.BlockOptionsTests;

public sealed class WhenWithMarkersIsCalled
{
    [Fact]
    public void GivenMarkersThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.BlockOptions();

        Snippet.BoundaryOptions markers = options.Markers
            .WithOpening("[")
            .WithClosing("]");

        // Act
        Snippet.BlockOptions result = options.WithMarkers(markers);

        // Assert
        result.ShouldNotBeSameAs(options);
        result.Markers.ShouldBe(markers);
        options.Markers.ShouldNotBe(markers);
    }
}