namespace MooVC.Syntax.Attributes.Resource.MetadataTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithXmlSpaceIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Metadata original = MetadataTestsData.Create();
        Snippet updated = Snippet.From("Other");

        // Act
        Metadata result = original.WithXmlSpace(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.XmlSpace.ShouldBe(updated);
        result.MimeType.ShouldBe(original.MimeType);
        result.Name.ShouldBe(original.Name);
        result.Type.ShouldBe(original.Type);
        result.Value.ShouldBe(original.Value);
    }
}