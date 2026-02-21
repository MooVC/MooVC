namespace MooVC.Syntax.Attributes.Resource.MetadataTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithMimeTypeIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Metadata original = MetadataTestsData.Create();
        var updated = Snippet.From("Other");

        // Act
        Metadata result = original.WithMimeType(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.MimeType.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
        result.Type.ShouldBe(original.Type);
        result.Value.ShouldBe(original.Value);
    }
}