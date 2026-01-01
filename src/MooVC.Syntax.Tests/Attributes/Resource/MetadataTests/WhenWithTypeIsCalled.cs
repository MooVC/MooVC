namespace MooVC.Syntax.Attributes.Resource.MetadataTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithTypeIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Metadata original = MetadataTestsData.Create();
        var updated = Snippet.From("Other");

        // Act
        Metadata result = original.WithType(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Type.ShouldBe(updated);
        result.MimeType.ShouldBe(original.MimeType);
        result.Name.ShouldBe(original.Name);
        result.Value.ShouldBe(original.Value);
    }
}